using Korelskiy.WW2Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Tank> Tanks { get; set; }
        public DbSet<SPA> SelfPropGuns { get; set; }
        public DbSet<Battleship> Battleships { get; set; }
        public DbSet<Submarine> Submarines { get; set; }
        public DbSet<AirAir> Fighters { get; set; }
        public DbSet<AirGround> Bombers { get; set; }
    }
}
