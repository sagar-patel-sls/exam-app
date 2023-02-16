using ExamApp.Domain;
using ExamApp.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Data
{
    public partial class ExamAppDBContext : DbContext
    {
        public ExamAppDBContext()
        {

        }
        public ExamAppDBContext(DbContextOptions<ExamAppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Uncomment for dev
                //optionsBuilder.UseInMemoryDatabase("Dev");

                optionsBuilder.UseSqlServer(
                    ConnectionStrings.DbConnection);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasMany(d => d.Students)
                    .WithOne(p => p.Course)
                    .HasForeignKey(d => d.CourseId);

                entity.HasOne(d => d.Language);
            });
        }
    }
}