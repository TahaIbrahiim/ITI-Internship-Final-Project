using Microsoft.EntityFrameworkCore;

namespace ITI_Project_withDB.Models
{
    public class ITIContext : DbContext
    {
        public ITIContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Final_project_learning;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
