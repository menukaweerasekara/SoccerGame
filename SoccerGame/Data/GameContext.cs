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

        public DbSet<Player> players { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public object Player { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Player>().ToTable("Student");
        }
    }
}