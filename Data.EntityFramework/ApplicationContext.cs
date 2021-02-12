using Microsoft.EntityFrameworkCore;
using Data.EntityFramework.Models;

namespace Data.EntityFramework
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<DictionaryDto> Dictionaries { get; set; }
        public DbSet<StudentDto> Students { get; set; }
        public DbSet<GroupDto> Groups { get; set; }
        public DbSet<GroupStudentDto> GroupStudents { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DictionaryDto>().ToTable("Dictionary");
            modelBuilder.Entity<StudentDto>().ToTable("Student");
            modelBuilder.Entity<GroupDto>().ToTable("Group");
            modelBuilder.Entity<GroupStudentDto>().ToTable("GroupStudent");
        }
    }
}
