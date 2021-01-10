using Korelskiy.WW2Project.Infrastructure;
using Korelskiy.WW2Project.Models;
using Korelskiy.WW2Project.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private IWebHostEnvironment _appEnvironment;

        public AccountController(IWebHostEnvironment environment,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _appEnvironment = environment;
        }
        [HttpPost]
        public IActionResult AddFile(IFormFile uploadedFile, int userId)
        {
            //if (uploadedFile != null)
            //{
            //    // путь к папке Files
            //    string path = "/img/" + uploadedFile.FileName;
            //    // сохраняем файл в папку Files в каталоге wwwroot
            //    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            //    {
            //        await uploadedFile.CopyToAsync(fileStream);
            //    }
            //    context.Users.Find(userId).AvatarPath = path;
            //    context.SaveChanges();
            //    SiteStatus.CurrentUser = context.Users.Find(userId);
            //}

            return RedirectToAction("Menu");
        }
        [AllowAnonymous]
        public IActionResult Menu(string returnUrl)
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Menu(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }
        public IActionResult ShowProfile()
        {
            return View(SiteStatus.CurrentUser);
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            Models.User user = new User();

            return View(user);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(User user, string password)
        {
            //context.Users.Add(user);
            //await context.SaveChangesAsync();
            

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "StandartUser")).GetAwaiter().GetResult();
            }

            return RedirectToAction("RandomView", "Main");
        }
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return Redirect("/Main/RandomView");
        }
    }
}
