using Microsoft.EntityFrameworkCore;
using SoccerGame.Models;

namespace SoccerGame.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        
        public DbSet<Division> Divisions { get; set; }
        
        public DbSet<Team> Teams { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>().ToTable("Division");

            modelBuilder.Entity<Player>().ToTable("Player");

            modelBuilder.Entity<Team>().ToTable("Team");



        }
    }
}