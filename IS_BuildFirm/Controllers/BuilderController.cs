using IS_BuildFirm.Models;
using IS_BuildFirm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_BuildFirm.Controllers
{
    [Authorize]
    public class BuilderController : Controller
    {
        private readonly ApplicationContext _context;

        public BuilderController(ApplicationContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var builders = await this._context.Builders.Include(b => b.Brigade).Include(b => b.Speciality).ToListAsync();
            return View(builders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("{controller=Builder}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var builder = await this._context.Builders.Include(b=>b.Speciality)
                .Include(b=>b.Brigade).FirstOrDefaultAsync(
                builder => builder.Id == id
            );
            if (builder != null)
                return View(builder);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BuilderViewModel vm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Валідація пройшла успішно";
                var s = this._context.Specialities.Find(vm.SpecialityId);
                var b = this._context.Brigades.Find(vm.BrigadeId);
                var builder = vm.Builder;
                builder.Brigade = b;
                builder.Speciality = s;
                this._context.Builders.Add(builder);
                await this._context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Запит не пройшов валідацію";
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var builder = await _context.Builders.FirstOrDefaultAsync(
                    builder => builder.Id == id
                );
                if (builder != null)
                    return View(builder);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Builder builder)
        {
            this._context.Builders.Update(builder);
            await this._context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var builder = await this._context.Builders.FirstOrDefaultAsync(
                    builder => builder.Id == id
                );
                if (builder == null)
                    return NotFound();
                this._context.Builders.Remove(builder);
                await this._context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Back()
        {
            return RedirectToAction("Index");
        }
    }
}
