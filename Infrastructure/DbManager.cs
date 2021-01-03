using Korelskiy.WW2Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Infrastructure
{
    public class DbManager : IDbManager
    {
        private readonly AppDbContext _context;
        public DbManager(AppDbContext context)
        {
            _context = context;
        }

        public List<WW2Item> GetAllItems()
        {
            List<Tank> tanks = _context.Tanks.ToList();
            List<SPA> sPAs = _context.SelfPropGuns.ToList();
            List<Battleship> battleships = _context.Battleships.ToList();
            List<Submarine> submarines = _context.Submarines.ToList();
            List<WW2Item> itms = new List<WW2Item>();
            itms.AddRange(tanks);
            itms.AddRange(sPAs);
            itms.AddRange(battleships);
            itms.AddRange(submarines);
            itms = itms.OrderByDescending(x => x.NumberOfProd).ToList();
            return itms;
        }

        public List<WW2Item> GetLandItems()
        {
            List<Tank> tanks = _context.Tanks.ToList();
            List<SPA> sPAs = _context.SelfPropGuns.ToList();
            List<WW2Item> itms = new List<WW2Item>();
            itms.AddRange(tanks);
            itms.AddRange(sPAs);
            itms = itms.OrderByDescending(x => x.NumberOfProd).ToList();
            return itms;
        }

        public List<WW2Item> GetSeaItems()
        {
            List<Battleship> battleships = _context.Battleships.ToList();
            List<Submarine> submarines = _context.Submarines.ToList();
            List<WW2Item> itms = new List<WW2Item>();
            itms.AddRange(battleships);
            itms.AddRange(submarines);
            itms = itms.OrderByDescending(x => x.NumberOfProd).ToList();
            return itms;
        }
    }
}
