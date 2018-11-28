using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCa.Models;
using WebAppCa.ViewModels;

namespace WebAppCa.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class MySchedulesController : Controller
    {
        private readonly BroadCastContext _context;

        public MySchedulesController(BroadCastContext context)
        {
            _context = context;
        }

        // GET: MySchedules
        public async Task<IActionResult> Index()
        {
            MySchedule mySchedule = new MySchedule();

            mySchedule.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var broadCastContext = _context.MySchedules.Include(m => m.Schedule).Include(m => m.Schedule.Channel).Include(m => m.Schedule.Programme).Where(m=>m.UserId==mySchedule.UserId);
     
            return View(await broadCastContext.ToListAsync());
        }

        // GET: MySchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySchedule = await _context.MySchedules
                .Include(m => m.Schedule)
                .FirstOrDefaultAsync(m => m.MyScheduleId == id);
            if (mySchedule == null)
            {
                return NotFound();
            }

            return View(mySchedule);
        }

        // GET: MySchedules/Create
        public IActionResult Create()
        {
            MySchedule mySchedule = new MySchedule();

            mySchedule.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            mySchedule.UserName= User.Identity.Name;



            ViewData["ScheduleID"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId");
            return View();
        }

        // POST: MySchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyScheduleId,UserName,ScheduleID")] MySchedule mySchedule)
        {
            mySchedule.UserName = User.Identity.Name;
            mySchedule.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (ModelState.IsValid)
            {
                _context.Add(mySchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleID"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", mySchedule.ScheduleID);
            return View(mySchedule);
        }

        // GET: MySchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySchedule = await _context.MySchedules.FindAsync(id);
            if (mySchedule == null)
            {
                return NotFound();
            }
            ViewData["ScheduleID"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", mySchedule.ScheduleID);
            return View(mySchedule);
        }

        // POST: MySchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyScheduleId,UserName,ScheduleID")] MySchedule mySchedule)
        {
            if (id != mySchedule.MyScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mySchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyScheduleExists(mySchedule.MyScheduleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleID"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", mySchedule.ScheduleID);
            return View(mySchedule);
        }

        // GET: MySchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mySchedule = await _context.MySchedules
                .Include(m => m.Schedule)
                .FirstOrDefaultAsync(m => m.MyScheduleId == id);
            if (mySchedule == null)
            {
                return NotFound();
            }

            return View(mySchedule);
        }

        // POST: MySchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mySchedule = await _context.MySchedules.FindAsync(id);
            _context.MySchedules.Remove(mySchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyScheduleExists(int id)
        {
            return _context.MySchedules.Any(e => e.MyScheduleId == id);
        }
    }
}
