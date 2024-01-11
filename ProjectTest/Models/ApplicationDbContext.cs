using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ProjectTest.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Exam> Exam { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.StudentId);

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentRollId)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentDOB)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder.Entity<Subject>()
                .HasKey(s => s.SubjectId);

            modelBuilder.Entity<Subject>()
                .Property(s => s.SubjectName)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Exam>()
                .HasKey(e => new { e.SubjectId, e.StudentId });

            modelBuilder.Entity<Exam>()
                .Property(e => e.Mark)
                .IsRequired();
        }
    }
}
