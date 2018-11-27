using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppCa.Models;

namespace WebAppCa.Controllers
{
    public class HomeController : Controller
    {
        private readonly BroadCastContext _context;
       
        public HomeController(BroadCastContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DateTime today = DateTime.Today;
            var broadCastContext = _context.Schedules.
                Include(s => s.Programme).
                Include(s => s.Channel).
                Where(s => s.AirDate == today).
                ToList();
            broadCastContext.ToList();

            return View(broadCastContext);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

    


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
