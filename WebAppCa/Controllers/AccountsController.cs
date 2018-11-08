using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppCa.ViewModels;

namespace WebAppCa.Controllers
{
  public class AccountController : Controller
        {
            UserManager<IdentityUser> userManager;
            SignInManager<IdentityUser> signInManager;

            public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
            {
                userManager = _userManager;
                signInManager = _signInManager;
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

                System.IO.File.WriteAllText(@"C:\Temp\ConfirmEmail.txt", confirmationLink);

                //Send Emal ----

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
                    return RedirectToAction("Index", "Home");
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Logout()
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Login", "Account");
            }
        }
    }