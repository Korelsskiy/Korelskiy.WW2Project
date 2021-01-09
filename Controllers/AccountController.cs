using Korelskiy.WW2Project.Infrastructure;
using Korelskiy.WW2Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext context;
        IWebHostEnvironment _appEnvironment;

        public AccountController(AppDbContext context, IWebHostEnvironment appEnvironment)
        {
            this.context = context;
            _appEnvironment = appEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile, int userId)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/img/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                context.Users.Find(userId).AvatarPath = path;
                context.SaveChanges();
                SiteStatus.CurrentUser = context.Users.Find(userId);
            }

            return RedirectToAction("Menu");
        }
       
        public IActionResult Menu()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Menu(string login, string password)
        {
            //SiteStatus.CurrentUser = context.Users.Where(x => x.UserName == login).ToList()[0];

            return RedirectToAction("RandomView", "Main");
        }
        public IActionResult ShowProfile()
        {
            return View(SiteStatus.CurrentUser);
        }
        public IActionResult Register()
        {
            Models.User user = new User();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return RedirectToAction("RandomView", "Main");
        }
    }
}
