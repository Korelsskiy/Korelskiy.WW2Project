using Korelskiy.WW2Project.Infrastructure;
using Korelskiy.WW2Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Controllers
{
    public class SeaController : Controller
    {
        private readonly IDbManager manager;

        public SeaController(IDbManager manager)
        {
            this.manager = manager;
        }
        public IActionResult Index()
        {
            return View(manager.GetSeaItems());
        }

        public IActionResult Detalis(string title)
        {
            WW2Item item = manager.GetSeaItems().FirstOrDefault(x => x.Title == title);
            return View(item);
        }
    }
}
