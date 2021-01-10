using Korelskiy.WW2Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Korelskiy.WW2Project.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Korelskiy.WW2Project.Controllers
{
    public class MainController : Controller
    {
        private static Random rnd = new Random();
        private readonly AppDbContext context;

        public MainController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Detalis(int id)
        {
            return View(await context.Items.FindAsync(id));
        }
        public async Task<IActionResult> RandomView()
        {
            List<WW2Item> items = await context.Items.ToListAsync();

            if (items.Count > 1)
            {
                List<WW2Item> rndItemsList = new List<WW2Item>() { };
                int rndItems = 2;

                int i = 0;
                if (items.Count > 0)
                {
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
                }
                return View(rndItemsList);
            }

            return View(items);
        }
        public async Task<IActionResult> Index(ModelTypes model)
        {
            List<WW2Item> items = new List<WW2Item>();
            switch (model)
            {
                case ModelTypes.Land:
                    items = await context.Items.Where(x => x.Type == ModelTypes.Land).ToListAsync();
                    break;
                case ModelTypes.Sea:
                    items = await context.Items.Where(x => x.Type == ModelTypes.Sea).ToListAsync();
                    break;
                case ModelTypes.Air:
                    items = await context.Items.Where(x => x.Type == ModelTypes.Air).ToListAsync();
                    break;
                default:
                    break;
            }

            return View(items);
        }
    }
}
