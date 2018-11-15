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
    public class ADMSchedulesController : Controller
    {
        private readonly BroadCastContext _context;

        public ADMSchedulesController(BroadCastContext context)
        {
            _context = context;
        }

        // GET: ADMSchedules
        public async Task<IActionResult> Index()
        {
            var broadCastContext = _context.Schedules.Include(s => s.Channel).Include(s => s.Programme);
            return View(await broadCastContext.ToListAsync());
        }

        // GET: ADMSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Channel)
                .Include(s => s.Programme)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: ADMSchedules/Create
        public IActionResult Create()
        {
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId");
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "ProgrammeId", "ProgrammeId");
            return View();
        }

        // POST: ADMSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleId,Image,AirDate,StartTime,EndTime,Sorting,ChannelId,ProgrammeId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId", schedule.ChannelId);
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "ProgrammeId", "ProgrammeId", schedule.ProgrammeId);
            return View(schedule);
        }

        // GET: ADMSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId", schedule.ChannelId);
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "ProgrammeId", "ProgrammeId", schedule.ProgrammeId);
            return View(schedule);
        }

        // POST: ADMSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleId,Image,AirDate,StartTime,EndTime,Sorting,ChannelId,ProgrammeId")] Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ScheduleId))
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
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId", schedule.ChannelId);
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "ProgrammeId", "ProgrammeId", schedule.ProgrammeId);
            return View(schedule);
        }

        // GET: ADMSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Channel)
                .Include(s => s.Programme)
                .FirstOrDefaultAsync(m => m.ScheduleId == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: ADMSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.ScheduleId == id);
        }
    }
}
