using Microsoft.EntityFrameworkCore;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Contexts
{
    public class CoursesDbContext : DbContext
    {
        public CoursesDbContext(DbContextOptions<CoursesDbContext> options)
            :
            base(options)
        {
            
        }
        public DbSet<CourseModel> Courses { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<GradeModel> Grades { get; set; }
    }
}