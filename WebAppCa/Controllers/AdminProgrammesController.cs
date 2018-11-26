using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCa.Models;

namespace WebAppCa.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProgrammesController : Controller
    {
        private readonly BroadCastContext _context;
        private IHostingEnvironment _env;

        public AdminProgrammesController(BroadCastContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: AdminProgrammes
        public async Task<IActionResult> Index()
        {
            var broadCastContext = _context.Programmes.Include(p => p.Category);
            return View(await broadCastContext.ToListAsync());
        }

        // GET: AdminProgrammes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programme = await _context.Programmes
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProgrammeId == id);
            if (programme == null)
            {
                return NotFound();
            }

            return View(programme);
        }

        // GET: AdminProgrammes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Title");
            return View();
        }

        // POST: AdminProgrammes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgrammeId,Title,Description,Image,Length,CategoryId, ProgrammeImageFile")] Programme programme, IFormFile ProgrammeImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ProgrammeImageFile != null)
                {
                    string upploadPath = Path.Combine(_env.WebRootPath, "Upploads");
                    Directory.CreateDirectory(Path.Combine(upploadPath, programme.ProgrammeId.ToString()));

                    string filename = ProgrammeImageFile.FileName;

                    if (filename.Contains("//"))
                    {
                        filename = filename.Split("\\").Last();
                    }

                    using (FileStream fs = new FileStream(Path.Combine(upploadPath, programme.ProgrammeId.ToString(), filename), FileMode.Create))
                    {
                        await ProgrammeImageFile.CopyToAsync(fs);
                    }
                    programme.Image = filename;
                }
           
                _context.Add(programme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", programme.CategoryId);
            return View(programme);
        }

        // GET: AdminProgrammes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
                                                         
            if (id == null)
            {
                return NotFound();
            }

            var programme = await _context.Programmes.FindAsync(id);
            if (programme == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", programme.CategoryId);
            return View(programme);
        }

        // POST: AdminProgrammes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ProgrammeId,Title,Description,Image,Length,CategoryId, ProgrammeImageFile")] Programme programme, IFormFile ProgrammeImageFile)
        {

            if (ModelState.IsValid)
            {
                if (ProgrammeImageFile != null)
                {
                    string upploadPath = Path.Combine(_env.WebRootPath, "Upploads");
                    Directory.CreateDirectory(Path.Combine(upploadPath, programme.ProgrammeId.ToString()));

                    string filename = ProgrammeImageFile.FileName;

                    if (filename.Contains("//"))
                    {
                        filename = filename.Split("\\").Last();
                    }

                    using (FileStream fs = new FileStream(Path.Combine(upploadPath, programme.ProgrammeId.ToString(), filename), FileMode.Create))
                    {
                        await ProgrammeImageFile.CopyToAsync(fs);
                    }
                    programme.Image = filename;
                }

                        _context.Update(programme);
                        await _context.SaveChangesAsync();
         
                    
                    return RedirectToAction(nameof(Index));
            }
                ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", programme.CategoryId);

                return View(programme);
            
        } 

        // GET: AdminProgrammes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programme = await _context.Programmes
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProgrammeId == id);
            if (programme == null)
            {
                return NotFound();
            }

            return View(programme);
        }

        // POST: AdminProgrammes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programme = await _context.Programmes.FindAsync(id);
            _context.Programmes.Remove(programme);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgrammeExists(int id)
        {
            return _context.Programmes.Any(e => e.ProgrammeId == id);
        }
    }
}
