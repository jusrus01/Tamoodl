using System.Threading.Tasks;
using TamoodlApi.Data.Contexts;
using System.Linq;
using TamoodlApi.Models;
using System;

namespace TamoodlApi.Data.Courses
{
    public class CoursesService : ICoursesService
    {
        private readonly CoursesDbContext _context;

        public CoursesService(CoursesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCourse(string courseName, string ownerEmail)
        {
            if(_context.Courses.Where(c => c.CourseName == courseName && c.OwnerEmail == ownerEmail).Any())
            {
                return false;
            }            

            await _context.AddAsync(new CourseModel
            {
                CourseName = courseName,
                OwnerEmail = ownerEmail,
                CreationDate = DateTime.Now
            });

            return true;
        }

        public CourseModel FindCourseByName(string courseName)
        {
            return _context.Courses.Where(c => c.CourseName == courseName).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool UpdateCourse(CourseModel model)
        {
            if(model == null)
            {
                return false;
            }
            _context.Courses.Update(model);

            return true;
        }

        public bool UpdateStudent(StudentAddModel model)
        {
            if(model == null)
            {
                return false;
            }
            _context.Students.Update(model);

            return true;
        }
    }
}