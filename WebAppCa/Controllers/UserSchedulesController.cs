using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCa.Models;

namespace WebAppCa.Controllers
{
    public class UserSchedulesController : Controller
    {
        private readonly BroadCastContext _context;

        public UserSchedulesController(BroadCastContext context)
        {
            _context = context;
        }

        // GET: UserSchedules
        public async Task<IActionResult> Index()
        {
            var broadCastContext = _context.UserSchedules.Include(u => u.Schedule).Include(u => u.User);
            return View(await broadCastContext.ToListAsync());
        }

        // GET: UserSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSchedule = await _context.UserSchedules
                .Include(u => u.Schedule)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserScheduleID == id);
            if (userSchedule == null)
            {
                return NotFound();
            }

            return View(userSchedule);
        }

        // GET: UserSchedules/Create
        public IActionResult Create()
        {
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: UserSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserScheduleID,UserId,ScheduleId")] UserSchedule userSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", userSchedule.ScheduleId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userSchedule.UserId);
            return View(userSchedule);
        }

        // GET: UserSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSchedule = await _context.UserSchedules.FindAsync(id);
            if (userSchedule == null)
            {
                return NotFound();
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", userSchedule.ScheduleId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userSchedule.UserId);
            return View(userSchedule);
        }

        // POST: UserSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserScheduleID,UserId,ScheduleId")] UserSchedule userSchedule)
        {
            if (id != userSchedule.UserScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserScheduleExists(userSchedule.UserScheduleID))
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
            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleId", userSchedule.ScheduleId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userSchedule.UserId);
            return View(userSchedule);
        }

        // GET: UserSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userSchedule = await _context.UserSchedules
                .Include(u => u.Schedule)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserScheduleID == id);
            if (userSchedule == null)
            {
                return NotFound();
            }

            return View(userSchedule);
        }

        // POST: UserSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userSchedule = await _context.UserSchedules.FindAsync(id);
            _context.UserSchedules.Remove(userSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserScheduleExists(int id)
        {
            return _context.UserSchedules.Any(e => e.UserScheduleID == id);
        }
    }
}
