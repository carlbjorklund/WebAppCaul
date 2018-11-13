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

        //public IActionResult AddChannel()
        //{

        //    ViewData["ChannelId"] = new SelectList(_context.Channels, "ChannelId", "Name");

        //    MyChannelViewModel model = new MyChannelViewModel();
        //    model.UserName = User.Identity.Name;
        //    model.UserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


        //    return View(model);


        //}

        public IActionResult AddChannel(int ? id)
        {
            MyChannelViewModel model = new MyChannelViewModel();

            model.UserName = User.Identity.Name;
            model.UserID = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
        
             var channel = _context.Channels
                .FirstOrDefault(m => m.ChannelId == id);


            model.MyChannels.Add(channel);

           

            if (ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChanges();
            }


                return View(model);
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