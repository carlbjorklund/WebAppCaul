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
    public class SchedulesController : Controller
    {
        private readonly BroadCastContext _context;

        //public ActionResult GetAwesomeResult()
        //{
        //    //ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "Title");
        //    //ViewBag.ChannelId = new SelectList(_context.Channels, "ChannelId", "Name");
        //    //ViewBag.ScheduleId = new SelectList(_context.Schedules, "ScheduleId", "AirDate");

        //    var List = _context.Schedules.Include(s => s.Channel).Include(s => s.Programme).Include(s => s.Programme.Category).ToList();

        //    //if (!String.IsNullOrEmpty(searchString))
        //    //{
        //    //    var list = _context.Schedules.Where(s=>s.Programme.Category.Title.Contains(searchString));

        //    //    //var students.Where(s => s.LastName.Contains(searchString)
        //    //    //                               || s.FirstMidName.Contains(searchString));
        //    //}


        //    return View(List);
        //}
        //public ViewResult GetAwesomeResult(string searchString)
        //{
        //    //ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "Title");
        //    //ViewBag.ChannelId = new SelectList(_context.Channels, "ChannelId", "Name");
        //    //ViewBag.ScheduleId = new SelectList(_context.Schedules, "ScheduleId", "AirDate");

        //    //var List = _context.Schedules.Include(s => s.Channel).Include(s => s.Programme).Include(s => s.Programme.Category).ToList();

        //    //if (!String.IsNullOrEmpty(searchString))
        //    //{
        //    //    //List = new List<Schedule>(_context.Schedules.Include(s => s.Channel).Include(s => s.Programme)
        //        //    .Include(s => s.Programme.Category).ThenInclude(s=>s.Title.Contains(searchString)));

        //        //List = new List<Schedule>(_context.Schedules.Include(s => s.Channel).Include(s => s.Programme)
        //        //    .Include(s => s.Programme.Category).Include(s => s.Programme.Category.Title.Contains(searchString)));

        //        var list = _context.Schedules.Include(p => p.Programme).Include(p=>p.Programme.Category.Title.Contains(searchString));


        //    //}


        //    return View(list);
        //}
        //, int? channelId, int? scheduleId
        public ActionResult GetAwesomeResult(int? categoryId, int? channelId)
        {
            var categories = _context.Categories.OrderBy(q => q.Title).ToList();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "Title", categoryId);

            var channels = _context.Channels.OrderBy(q => q.Name).ToList();
            ViewData["ChannelId"] = new SelectList(channels,"ChannelId", "Name", channelId);

           

            var broadCastContext1 = _context.Schedules.Include(s => s.Channel).Include(s => s.Programme)
                .Include(s => s.Programme.Category).ToList();


            if (categoryId != 0)
            {
                broadCastContext1 = _context.Schedules.Where(s => s.Programme.CategoryId == categoryId).ToList();
            }

            if (channelId != 0)
            {
                broadCastContext1 = _context.Schedules.Where(s => s.ChannelId == channelId).ToList();
            }

        



            return View(broadCastContext1);
        }

        public SchedulesController(BroadCastContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            //var broadCastContext = _context.Schedules.Include(s => s.Channel).Include(s => s.Programme);
            var broadCastContext2 = _context.Schedules.Include(s => s.Channel).Include(s => s.Programme).Include(s=>s.Programme.Category);
            return View(await broadCastContext2.ToListAsync());
        }

        // GET: Schedules/Details/5
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

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId");
            ViewData["ProgrammeId"] = new SelectList(_context.Programmes, "ProgrammeId", "ProgrammeId");
            return View();
        }

        // POST: Schedules/Create
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

        // GET: Schedules/Edit/5
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

        // POST: Schedules/Edit/5
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

        // GET: Schedules/Delete/5
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

        // POST: Schedules/Delete/5
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
