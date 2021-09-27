using System.Threading.Tasks;
using TamoodlApi.Data.Contexts;
using System.Linq;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Teachers
{
    public class TeachersService : ITeachersService
    {
        private readonly CoursesDbContext _context;
        public TeachersService(CoursesDbContext context)
        {
            _context = context;
        }
        public Task<bool> AddGrade(CourseModel currentCourse, StudentModel student, byte grade)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddStudent(StudentModel model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> CreateCourse(CourseModel model)
        {
            if(_context.Courses.Where(c => c.Equals(model)).Any())
            {
                return false;
            }

            await _context.AddAsync(model);

            return true;
        }

        public Task<bool> RemoveGrade(CourseModel currentCourse, StudentModel student, byte grade)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveStudent(StudentModel model)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task<bool> UpdateGrade(CourseModel currentCourse, StudentModel student, byte grade)
        {
            throw new System.NotImplementedException();
        }

        public Task<CourseModel> ViewCourse(string courseName)
        {
            throw new System.NotImplementedException();
        }
    }
}