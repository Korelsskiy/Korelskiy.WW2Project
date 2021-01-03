using Korelskiy.WW2Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korelskiy.WW2Project.Infrastructure;

namespace Korelskiy.WW2Project.Controllers
{
    public class MainController : Controller
    {
        private static Random rnd = new Random();
        private readonly IDbManager manager;

        public MainController(IDbManager manager)
        {
            this.manager = manager;
        }
        public IActionResult Index()
        {
            List<WW2Item> items = manager.GetAllItems();

            List<WW2Item> rndItemsList = new List<WW2Item>() { };
            int rndItems = 2;

            int i = 0;
            do
            {
                WW2Item itm = items[rnd.Next(0, items.Count)];
                if (!rndItemsList.Contains(itm))
                {
                    rndItemsList.Add(itm);
                    i++;
                }

            }
            while (i < rndItems);
            

            return View(rndItemsList);
        }
    }
}
