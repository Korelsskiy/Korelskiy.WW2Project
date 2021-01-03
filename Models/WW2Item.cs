using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Models
{
    public class WW2Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
       // public string TitleImage { get; set; }
        public string ImageFolder { get; set; }
        public string Country { get; set; }
        public int NumberOfProd { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }
        public string Weapons { get; set; }
        public int Weight { get; set; }
    }
}
