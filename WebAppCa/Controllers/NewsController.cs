using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCa.Models;

namespace WebAppCa.Controllers
{
    public class NewsController : Controller
    {
        private readonly BroadCastContext _context;
        private IHostingEnvironment _env;

        public NewsController(BroadCastContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

       

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,Title,Description,Image,IssueDate, NewsImageFile")] News news, IFormFile NewsImageFile)
        {
            if (ModelState.IsValid)
            {
                if (NewsImageFile!=null)
            {
                string upploadPath = Path.Combine(_env.WebRootPath, "Upploads");
                Directory.CreateDirectory(Path.Combine(upploadPath, news.NewsId.ToString()));

                string filename = NewsImageFile.FileName;

                    if (filename.Contains("//"))
                    {
                        filename = filename.Split("\\").Last();
                    }

                    using (FileStream fs = new FileStream(Path.Combine(upploadPath, news.NewsId.ToString(), filename), FileMode.Create))
                    {
                        await NewsImageFile.CopyToAsync(fs);
                    }
                    news.Image = filename;
            }

           
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit( int?Id)
        {
            var news = await _context.News.FindAsync(Id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("NewsId,Title,Description,Image,IssueDate")] News news, IFormFile NewsImageFile)
        {
           

            if (ModelState.IsValid)
            {
                if (NewsImageFile != null)
                {
                    string upploadPath = Path.Combine(_env.WebRootPath, "Upploads");
                    Directory.CreateDirectory(Path.Combine(upploadPath, news.NewsId.ToString()));

                    string filename = NewsImageFile.FileName;

                    if (filename.Contains("//"))
                    {
                        filename = filename.Split("\\").Last();
                    }

                    using (FileStream fs = new FileStream(Path.Combine(upploadPath, news.NewsId.ToString(), filename), FileMode.Create))
                    {
                        await NewsImageFile.CopyToAsync(fs);
                    }
                    news.Image = filename;
                }


                _context.Update(news);
                await _context.SaveChangesAsync();
            }
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
