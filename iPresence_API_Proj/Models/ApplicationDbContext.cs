using Microsoft.EntityFrameworkCore;

namespace iPresence_API_Proj.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Student_activity> Student_activity { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student_activity>()
                .HasOne(sa => sa.StudentFk)
                .WithMany()
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Student_activity>()
                .HasOne(sa => sa.ClassFk)
                .WithMany()
                .HasForeignKey(sa => sa.ClassId)
                .OnDelete(DeleteBehavior.Restrict); 

            base.OnModelCreating(modelBuilder);
        }

    }
}
