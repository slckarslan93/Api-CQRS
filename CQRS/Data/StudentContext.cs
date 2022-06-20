using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student(){Name="Selçuk",Age=29,Surname="Arslan",Id=1},
                new Student(){Name="Ali",Age=25,Surname="Veli",Id=2}
            });
            base.OnModelCreating(modelBuilder);
        }


    }
}
