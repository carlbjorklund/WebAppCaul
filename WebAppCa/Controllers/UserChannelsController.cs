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
    public class UserChannelsController : Controller
    {
        private readonly BroadCastContext _context;

        public UserChannelsController(BroadCastContext context)
        {
            _context = context;
        }

        // GET: UserChannels
        public async Task<IActionResult> Index()
        {
            var broadCastContext = _context.UserChannels.Include(u => u.Channel).Include(u => u.User);
            return View(await broadCastContext.ToListAsync());
        }

        // GET: UserChannels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userChannel = await _context.UserChannels
                .Include(u => u.Channel)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserChannelId == id);
            if (userChannel == null)
            {
                return NotFound();
            }

            return View(userChannel);
        }

        // GET: UserChannels/Create
        public IActionResult Create()
        {
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return View();
        }

        // POST: UserChannels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserChannelId,UserId,ChannelId")] UserChannel userChannel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userChannel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId", userChannel.ChannelId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userChannel.UserId);
            return View(userChannel);
        }

        // GET: UserChannels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userChannel = await _context.UserChannels.FindAsync(id);
            if (userChannel == null)
            {
                return NotFound();
            }
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId", userChannel.ChannelId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userChannel.UserId);
            return View(userChannel);
        }

        // POST: UserChannels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserChannelId,UserId,ChannelId")] UserChannel userChannel)
        {
            if (id != userChannel.UserChannelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userChannel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserChannelExists(userChannel.UserChannelId))
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
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "ChannelId", userChannel.ChannelId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId", userChannel.UserId);
            return View(userChannel);
        }

        // GET: UserChannels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userChannel = await _context.UserChannels
                .Include(u => u.Channel)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserChannelId == id);
            if (userChannel == null)
            {
                return NotFound();
            }

            return View(userChannel);
        }

        // POST: UserChannels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userChannel = await _context.UserChannels.FindAsync(id);
            _context.UserChannels.Remove(userChannel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserChannelExists(int id)
        {
            return _context.UserChannels.Any(e => e.UserChannelId == id);
        }
    }
}
