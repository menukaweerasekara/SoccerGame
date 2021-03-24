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
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<SoccerAssignment> SoccerAssignments { get; set; }
        public DbSet<GameAssignment> gameAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>().ToTable("Coach");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Team>().ToTable("Team");
            modelBuilder.Entity<SoccerAssignment>().ToTable("SoccerAssignmnet");
            modelBuilder.Entity<GameAssignment>().ToTable("GameAssignment");

            modelBuilder.Entity<GameAssignment>()
                .HasKey(c => new { c.CoachID, c.TeamID });
        }
    }
}