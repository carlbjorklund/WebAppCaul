using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ResultOperators.Internal;
using WebAppCa.Models;

namespace WebAppCa.Controllers
{
    public class ProgrammesController : Controller
    {
        private readonly BroadCastContext _context;

        public ProgrammesController(BroadCastContext context)
        {
            _context = context;
        }

        // GET: Programmes
       
        public async Task<IActionResult> Index()
        {
         
            var broadCastContext = _context.Programmes.Include(p => p.Category);
            return View(await broadCastContext.ToListAsync());
        }

        //public async Task<IActionResult> Edit( int? id)
        //{
        //    var categories = _context.Categories.OrderBy(q => q.Title).ToList();
        //    ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "Title", id);
        //    int categoryId = id.GetHashCode();

        //    var programmes = _context.Programmes
        //        .Where(c =>c.CategoryId == id)
        //        .OrderBy(d => d.CategoryId)
        //        .Include(d => d.Category);
        //    //var sql = programmes.ToString();
        //    return View(await programmes.ToListAsync());
        //}

        /// <summary>
        /// borde funka
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Route("programmes/GetCategories/{id}")]
        ////public async Task<IActionResult> GetCategories(int? id)
        //{
        //    var categories = _context.Categories.OrderBy(q => q.Title).ToList();
        //    ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "Title", id);
        //    int categoryId = id.GetValueOrDefault();

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var programme = _context.Programmes.Where(c=>c.CategoryId==id);




        //    return View(await programme.ToListAsync());
        //}
        //public ActionResult Index2(int? selectedCategory)
        //{
        //    //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Title");
        //    var categories = _context.Categories.OrderBy(q => q.Title).ToList();
        //    ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "Title", selectedCategory);
        ////    int categoryId = selectedCategory.GetValueOrDefault();

        //    var programmes = _context.Programmes
        //        .Where(c => !selectedCategory.HasValue || c.CategoryId == categoryId)
        //        .OrderBy(d => d.CategoryId)
        //        .Include(d => d.Category);
        //    //var sql = programmes.ToString();
        //    return View(programmes.ToList());
        //}

        /// <summary>
        /// funkar
        /// </summary>
        /// <param name="selectedCategory"></param>
        /// <returns></returns>
        //[Route("programmes/CategoryId/{id}")]

        //[HttpGet("[controller]/[action]/{id}")]
        public ActionResult GetCategories(int? CategoryId)
        {
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Title");
            var categories = _context.Categories.OrderBy(q => q.Title).ToList();
            ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "Title", CategoryId);
            int categoryId = CategoryId.GetValueOrDefault();

            var programmes = _context.Programmes
                .Where(c => !CategoryId.HasValue || c.CategoryId == categoryId)
                .OrderBy(d => d.CategoryId)
                .Include(d => d.Category);
            //var sql = programmes.ToString();
            return View(programmes.ToList());
        }



        //public async Task<IActionResult> GetCategories(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var categories = _context.Categories.OrderBy(q => q.Title).ToList();
        //    ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "Title", search);
        //    int categoryId = selectedCategory.GetValueOrDefault();
        //    var programmes = _context.Programmes
        //        .Where(c => !id.HasValue || c.CategoryId == id)
        //        .OrderBy(d => d.CategoryId)
        //        .Include(d => d.Category);
        //    if (programme == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(programme);
        //}

        //public ActionResult Index2(string search)
        //{
        //    //ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Title");
        //    //IQueryable<Programme> custQuery =
        //    //    from p in _context.Categories
        //    //    where p.Title == "search".SelectMany("Title");
        //    //var categories = _context.Categories.OrderBy(q => q.Title).ToList();
        //    //ViewBag.SelectedCategory = new SelectList(categories, "CategoryId", "Title", SelectedCategory);
        //    //int CategoryId = SelectedCategory.GetValueOrDefault();

        //    //IQueryable<Programme> programmes = _context.Programmes
        //    //    .Where(c => !SelectedCategory.HasValue || c.CategoryId == CategoryId)
        //    //    .OrderBy(d => d.CategoryId)
        //    //    .Include(d => d.Category);
        //    //var sql = programmes.ToString();
        //    //return View(programmes.ToList());


        //    var broadCastContext = _context.Programmes.Include(p => p.Category).ThenInclude(p => p.Title.Contains("search"));
        //    return View(broadCastContext.ToList());
        //}
        // GET: Programmes/Details/5
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

        // GET: Programmes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Programmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgrammeId,Title,Description,Image,Length,CategoryId")] Programme programme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", programme.CategoryId);
            return View(programme);
        }

        // GET: Programmes/Edit/5
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

        // POST: Programmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgrammeId,Title,Description,Image,Length,CategoryId")] Programme programme)
        {
            if (id != programme.ProgrammeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammeExists(programme.ProgrammeId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", programme.CategoryId);
            return View(programme);
        }

        // GET: Programmes/Delete/5
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

        // POST: Programmes/Delete/5
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
