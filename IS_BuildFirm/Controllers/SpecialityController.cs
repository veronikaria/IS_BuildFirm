using IS_BuildFirm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IS_BuildFirm.Controllers
{
    [Authorize]
    public class SpecialityController : Controller
    {
        private readonly ApplicationContext _context;

        public SpecialityController(ApplicationContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var specialities = await this._context.Specialities.ToListAsync();
            return View(specialities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("{controller=Speciality}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var speciality = await this._context.Specialities.FirstOrDefaultAsync(p => p.Id == id);
            if (speciality != null)
                return View(speciality);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Валідація пройшла успішно";
                this._context.Specialities.Add(speciality);
                await this._context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Запит не пройшов валідацію";
            return View(speciality);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var speciality = await _context.Specialities.FirstOrDefaultAsync(p => p.Id == id);
                if (speciality != null)
                    return View(speciality);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Speciality speciality)
        {
            this._context.Specialities.Update(speciality);
            await this._context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var speciality = await this._context.Specialities.FirstOrDefaultAsync(p => p.Id == id);
                if (speciality == null)
                    return NotFound();
                this._context.Specialities.Remove(speciality);
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
