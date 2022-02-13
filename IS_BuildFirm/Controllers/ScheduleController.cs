using IS_BuildFirm.Models;
using IS_BuildFirm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.             Threading.Tasks;

namespace IS_BuildFirm.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly ApplicationContext _context;

        public ScheduleController(ApplicationContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(SortStatus status = SortStatus.DateStartAsc)
        {
            var schedules = await this._context.Schedules.Include(s => s.Brigade).ToListAsync();
            if (status == SortStatus.AddressAsc)
                ViewData["AddressSort"] = SortStatus.AddressDesc;
            else 
                ViewData["AddressSort"] = SortStatus.AddressAsc;
            if (status == SortStatus.DateStartAsc)
                ViewData["DateStartSort"] = SortStatus.DateStartDesc;
            else 
                ViewData["DateStartSort"] = SortStatus.DateStartAsc;
            if (status == SortStatus.DateEndAsc)
                ViewData["DateEndSort"] = SortStatus.DateEndDesc;
            else
                ViewData["DateEndSort"] = SortStatus.DateEndAsc;
            if (status == SortStatus.BrigadeAsc)
                ViewData["BrigadeSort"] = SortStatus.BrigadeDesc;
            else
                ViewData["BrigadeSort"] = SortStatus.BrigadeAsc;

            switch (status)
            {
                case SortStatus.AddressAsc:
                    schedules = schedules.OrderBy(s => s.Address).ToList();
                    break;
                case SortStatus.AddressDesc:
                    schedules = schedules.OrderByDescending(s => s.Address).ToList();
                    break;
                case SortStatus.BrigadeAsc:
                    schedules = schedules.OrderBy(s => s.Brigade.Name).ToList();
                    break;
                case SortStatus.BrigadeDesc:
                    schedules = schedules.OrderByDescending(s => s.Brigade.Name).ToList();
                    break;
                case SortStatus.DateStartAsc:
                    schedules = schedules.OrderBy(s => s.StartDate).ToList();
                    break;
                case SortStatus.DateStartDesc:
                    schedules = schedules.OrderByDescending(s => s.StartDate).ToList();
                    break;
                case SortStatus.DateEndAsc:
                    schedules = schedules.OrderBy(s => s.EndDate).ToList();
                    break;
                case SortStatus.DateEndDesc:
                    schedules = schedules.OrderByDescending(s => s.EndDate).ToList();
                    break;
                default:
                    break;
            }
            return View(schedules);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("{controller=Schedule}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var schedule = await this._context.Schedules.Include(s=>s.Brigade).FirstOrDefaultAsync(
                schedule => schedule.Id == id
            );
            if (schedule != null)
                return View(schedule);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ScheduleViewModule vm)
        {
            if (ModelState.IsValid)
            {
                Schedule s = vm.Schedule;
                s.Brigade = this._context.Brigades.Find(vm.BrigadeId);
                ViewBag.Message = "Валідація пройшла успішно";
                this._context.Schedules.Add(s);
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
                var schedule = await _context.Schedules.Include(s=>s.Brigade).FirstOrDefaultAsync(
                    schedule => schedule.Id == id
                );
                if (schedule != null)
                    return View(schedule);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Schedule schedule)
        {
            this._context.Schedules.Update(schedule);
            await this._context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var schedule = await this._context.Schedules.FirstOrDefaultAsync(
                    schedule => schedule.Id == id
                );
                if (schedule == null)
                    return NotFound();
                this._context.Schedules.Remove(schedule);
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
