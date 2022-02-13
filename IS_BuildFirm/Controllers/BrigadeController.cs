using IS_BuildFirm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace IS_BuildFirm.Controllers
{
    [Authorize]
    public class BrigadeController : Controller
    {
        private readonly ApplicationContext _context;

        public BrigadeController(ApplicationContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brigades = await this._context.Brigades.ToListAsync();
            return View(brigades);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Brigade brigade)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Валідація пройшла успішно";
                this._context.Brigades.Add(brigade);
                await this._context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Запит не пройшов валідацію";
            return View(brigade);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var brigade = await _context.Brigades.FirstOrDefaultAsync(
                    brigade => brigade.Id == id
                );
                if (brigade != null)
                    return View(brigade);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Brigade brigade)
        {
            this._context.Brigades.Update(brigade);
            await this._context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var brigade = await this._context.Brigades.FirstOrDefaultAsync(
                     brigade => brigade.Id == id
                );
                if (brigade == null)
                    return NotFound();
                this._context.Brigades.Remove(brigade);
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
