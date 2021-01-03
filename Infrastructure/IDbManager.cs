using Korelskiy.WW2Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Infrastructure
{
    public interface IDbManager
    {
        public List<WW2Item> GetLandItems();
        public List<WW2Item> GetSeaItems();

        public List<WW2Item> GetAllItems();
    }
}
