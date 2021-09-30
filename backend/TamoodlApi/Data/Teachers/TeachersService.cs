using System.Threading.Tasks;
using TamoodlApi.Data.Contexts;
using System.Linq;
using TamoodlApi.Models;
using System;
using TamoodlApi.Data.Courses;

namespace TamoodlApi.Data.Teachers
{
    public class TeachersService : ITeachersService
    {
        private readonly CoursesDbContext _context;
        private readonly ICoursesService _coursesService;

        public TeachersService(CoursesDbContext context, ICoursesService coursesService)
        {
            _context = context;
            _coursesService = coursesService;
        }
        public bool AddGrade(AddGradeModel model)
        {
            if (model == null)
            {
                return false;
            }

            var foundStudent = _context.Students.Where(s => s.CourseName == model.CourseName && s.Student.Email == model.StudentEmail).FirstOrDefault();

            if (foundStudent == null)
            {
                return false;
            }

            foundStudent.Student.Grades.Append(new GradeModel
            {
                CreationDate = DateTime.Now,
                Grade = model.Grade
            });

            if (_coursesService.UpdateStudent(foundStudent))
            {
                return true;
            }

            return false;
        }

        public async Task<CourseModel> AddStudent(CourseModel course, StudentAddModel model)
        {
            if (course == null || model == null)
            {
                return null;
            }

            else if (_context.Students.Where(s => s.Student.Email == model.Student.Email &&
                 s.CourseName == model.CourseName).Any())
            {
                return null;
            }
            else
            {
                await _context.Students.AddAsync(model);
            }

            return course;
        }

        public async Task<bool> CreateCourse(CourseModel model)
        {
            if (_context.Courses.Where(c => c.CourseName == model.CourseName).Any())
            {
                return false;
            }

            await _context.AddAsync(model);

            return true;
        }

        public CourseModel FindCourseByName(string courseName)
        {
            return _context.Courses.Where(c => c.CourseName == courseName).FirstOrDefault();
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