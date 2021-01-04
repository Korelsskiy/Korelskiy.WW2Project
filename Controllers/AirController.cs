using Korelskiy.WW2Project.Infrastructure;
using Korelskiy.WW2Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Controllers
{
    public class AirController : Controller
    {
        private readonly IDbManager manager;

        public AirController(IDbManager manager)
        {
            this.manager = manager;
        }
        public IActionResult Index()
        {
            return View(manager.GetAirItems());
        }

        public IActionResult Detalis(string title)
        {
            WW2Item item = manager.GetAirItems().FirstOrDefault(x => x.Title == title);
            return View(item);
        }
    }
}
