using Microsoft.EntityFrameworkCore;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Data
{
    public class DbContextClass : DbContext
    {
      

        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
           
        }

        public DbSet<StudentDetails> Students { get; set; }
        public DbSet<FileDetails> FileDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDetails>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.StudentId).ValueGeneratedNever();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
