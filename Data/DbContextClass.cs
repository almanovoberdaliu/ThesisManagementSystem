using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Availability> Availability { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDetails>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.StudentId).ValueGeneratedNever();
            });

            modelBuilder.Entity<StudentDetails>()
                .HasOne(s => s.FileDetails)
                .WithMany()
                .HasForeignKey(s => s.ID)
                .OnDelete(DeleteBehavior.Restrict); // or use appropriate delete behavior

            // Configure the foreign key for Specialization
            modelBuilder.Entity<StudentDetails>()
                .HasOne(s => s.Specialization)
                .WithMany()
                .HasForeignKey(s => s.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
