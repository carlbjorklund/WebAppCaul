using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCa.Models;
using WebAppCa.Services;
using WebAppCa.ViewModels;

namespace WebAppCa.Controllers
{
  public class AccountController : Controller
        {
            UserManager<IdentityUser> userManager;
            SignInManager<IdentityUser> signInManager;
            MyChannelViewModel myChannel;




        private readonly BroadCastContext _context;


        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager, BroadCastContext context)
            {
                userManager = _userManager;
                signInManager = _signInManager;
               _context = context;
            }

            public IActionResult Index()
            {
                return View();
            }

            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }

        public ActionResult AddChannel(int? id)
        {

            MyChannelViewModel myChannel = new MyChannelViewModel();
            Channel channel1 = new Channel();
            if (id == null)
            {
                return NotFound();
            }

            //ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "Name");

            var channel = _context.Channels
                 .FirstOrDefault(m => m.ChannelId == id);
            if (channel == null)
            {
                return NotFound();
            }

            //channel1.ChannelId = channel.ChannelId;
            //channel1.Description = channel.Description;
            //channel1.Name = channel.Name;


            myChannel.UserName = User.Identity.Name;
            myChannel.UserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            myChannel.MyChannels.Add(channel);


            //if (ModelState.IsValid)
            //{
            //    _context.Add(myChannel);
            //    _context.SaveChanges();
            //    return RedirectToAction(nameof(Index));
            //}


            //var channels = _context.Channels.ToListAsync();
            //var channels = _context.Channels.OrderBy(q => q.Name).ToList();
            //ViewData["ChannelId"] = new SelectList(channels, "ChannelId", "Name");
            //ViewData["ChannelId"] = new SelectList(channels, "ChannelId", "Name");


            return View(myChannel);
           
        }

        /// <summary>
        /// here the view model decides to become non-existent and disapear into cyberspace, eventhough there is a global variable
        /// </summary>
        /// <param name="myChannel"></param>
        /// <returns></returns>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddChannel(/*[Bind("ChannelID, Name,Description,Image, UserId")]*/ MyChannelViewModel myChannel)
        {

            //myChannel.UserName = User.Identity.Name;
            //myChannel.UserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                _context.Add(myChannel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "Name");

            return View(myChannel);
        }
        //public ActionResult AddChannel(int? Id)
        //{
        //    MyChannelViewModel myChannel = new MyChannelViewModel();

        //    myChannel.UserName = User.Identity.Name;
        //    myChannel.UserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "Name");
        //    //var channels = _context.Channels.ToListAsync();
        //    //var channels = _context.Channels.OrderBy(q => q.Name).ToList();
        //    //ViewData["ChannelId"] = new SelectList(channels, "ChannelId", "Name");



        //    return View(myChannel);

        //}

        [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel model)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);
                string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                string confirmationLink = Url.Action("ConfirmEmail", "Account", new { userid = user.Id, token = confirmationToken }, protocol: HttpContext.Request.Scheme);
                System.IO.File.WriteAllText(@"D:\Confirmations\ConfirmEmail.txt", confirmationLink);

                //EmailService.Send(user.Email, "Awaiting email confirmation", "Please confirm your email " + confirmationLink);

            if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }

                return View();
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel model)
            {
                var Result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
                if (Result.Succeeded)
                    return RedirectToAction("Index", "Account");
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.Msg = "Email confirmation Succeeded!";
            }
            else
            {
                ViewBag.Msg = "Email confirmation Failed!";
            }

            return View();
        }
    }
 }