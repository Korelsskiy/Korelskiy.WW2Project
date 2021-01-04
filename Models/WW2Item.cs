using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Models
{
    public class WW2Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageFolder { get; set; }
        public string CountryFlagImage { get; set; }
        public ModelTypes Type { get; set; }
        public bool IsVechicle { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
        public string Weapon { get; set; }
        public int ProductionCount { get; set; }
    }
}
