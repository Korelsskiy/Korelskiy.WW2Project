using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korelskiy.WW2Project.Models;
using Korelskiy.WW2Project.Infrastructure;

namespace Korelskiy.WW2Project.Controllers
{
    public class LandController : Controller
    {
        private readonly IDbManager manager;

        public LandController(IDbManager manager)
        {
            this.manager = manager;
        }
        public IActionResult Index()
        {
            return View(manager.GetLandItems());
        }

        public IActionResult Detalis(string title)
        {
            WW2Item item = manager.GetLandItems().FirstOrDefault(x => x.Title == title);
            return View(item);
        }
    }
}
