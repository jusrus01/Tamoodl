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

        public async Task<CourseModel> AddCourse(CourseModel newCourse)
        {
            if(FindCourse(newCourse) == null)
            {
                await _context.Courses.AddAsync(newCourse);
                return newCourse;
            }
            
            return null;
        }

        public CourseModel FindCourse(CourseModel course)
        {
            return _context.Courses.Where(c => c.CourseName == course.CourseName &&
                c.OwnerEmail == course.OwnerEmail).FirstOrDefault();
        }

        public CourseModel FindCourseByName(string courseName)
        {
            return _context.Courses.Where(c => c.CourseName == courseName).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}