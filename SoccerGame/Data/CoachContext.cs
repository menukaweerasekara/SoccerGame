using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Models;

namespace SoccerGame.Data
{
    public class CoachContext : DbContext

    {
        public CoachContext(DbContextOptions<CoachContext> options)
            : base(options)
        {
        }

     
        public DbSet<Coach> Coaches { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>().ToTable("Coach");
            modelBuilder.Entity<Player>().ToTable("player");

        }
    }
}
