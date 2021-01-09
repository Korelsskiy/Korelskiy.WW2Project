using Korelskiy.WW2Project.Infrastructure;
using Korelskiy.WW2Project.Models;
using Korelskiy.WW2Project.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AdminController(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "Administrator")]
        public IActionResult Administrator()
        {
            return View();
        }
        [Authorize(Policy = "Manager")]
        public IActionResult Manager()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var user = await context.Users.
            //    SingleOrDefaultAsync(x => x.UserName == model.UserName && x.Password == model.Password);

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            //var claims = new List<Claim>()
            //{
            //    new Claim(ClaimTypes.Name, model.UserName),
            //    new Claim(ClaimTypes.Role, "Administrator")
            //};
            //var claimIdientity = new ClaimsIdentity(claims, "Cookie");
            //var claimPrincipal = new ClaimsPrincipal(claimIdientity);
            //await HttpContext.SignInAsync("Cookie", claimPrincipal);

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return Redirect("/Main/RandomView");
        }
    }
}
