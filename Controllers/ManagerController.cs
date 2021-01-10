using Korelskiy.WW2Project.Infrastructure;
using Korelskiy.WW2Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class ManagerController : Controller
    {
        private readonly AppDbContext context;

        public ManagerController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Menu()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Menu(int id)
        {
            WW2Item item = await context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            context.Items.Remove(item);
            await context.SaveChangesAsync();

            ViewData["Message"] = "Статья удалена";

            return View();
        }
        public IActionResult Index() => View();
        [HttpPost]
        public async Task<IActionResult> Index(WW2Item item)
        {
            if (ModelState.IsValid)
            {
                await context.Items.AddAsync(item);
                await context.SaveChangesAsync();

                return RedirectToAction("RandomView", "Main");
            }
            
            return View(item);
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            WW2Item item = await context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }


            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WW2Item item)
        {
            if (ModelState.IsValid)
            {
                context.Items.Update(item);
                await context.SaveChangesAsync();

            }
            return View(item);
        }
    }
}
