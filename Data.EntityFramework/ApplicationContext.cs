using Microsoft.EntityFrameworkCore;
using Data.EntityFramework.Models;

namespace Data.EntityFramework
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Dictionary> Dictionaries { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupStudent> GroupStudents { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictionary>().ToTable("Dictionary");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<GroupStudent>().ToTable("GroupStudent");
        }
    }
}
