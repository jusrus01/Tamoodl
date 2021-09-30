using System.Threading.Tasks;
using TamoodlApi.Data.Contexts;
using TamoodlApi.Models;
using System.Linq;
using System.Collections.Generic;

namespace TamoodlApi.Data.Students
{
    public class StudentsService : IStudentsService
    {
        private readonly CoursesDbContext _context;

        public StudentsService(CoursesDbContext context)
        {
            _context = context;
        }

        // Assuming that each course has a unique name
        public async Task<StudentModel> ViewGrades(string studentsEmail, string courseName)
        {
            var course =_context.Courses.Where(c => c.CourseName == courseName).FirstOrDefault();

            if(course == null)
            {
                return null;
            }

            // return _context.Students.Where(s => s.Email == studentsEmail).FirstOrDefault();
            return null;
        }
    }
}