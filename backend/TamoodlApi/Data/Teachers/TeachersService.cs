using System.Threading.Tasks;
using TamoodlApi.Data.Contexts;
using System.Linq;
using TamoodlApi.Models;
using System;
using TamoodlApi.Data.Courses;
using TamoodlApi.Data.Students;
using System.Collections.Generic;

namespace TamoodlApi.Data.Teachers
{
    public class TeachersService : ITeachersService
    {
        private readonly CoursesDbContext _context;
        private readonly ICoursesService _coursesService;
        private readonly IStudentsService _studentsService;

        public TeachersService(
            CoursesDbContext context,
            ICoursesService coursesService,
            IStudentsService studentsService
            )
        {
            _context = context;
            _coursesService = coursesService;
            _studentsService = studentsService;
        }
        public StudentModel AddGrade(AddGradeModel model)
        {
            var student = _studentsService.FindStudent(model.CourseName, model.StudentEmail);

            if(student == null)
            {
                return null;
            }

            student.Grades = _context.Grades.Where(grade =>
                grade.CourseName == student.CourseName &&
                grade.StudentEmail == student.Email).ToList();

            if(student.Grades == null)
            {
                student.Grades = new List<GradeModel>();
            }

            _context.Grades.Add(
                new GradeModel
                {
                    CourseName = model.CourseName,
                    StudentEmail = model.StudentEmail,
                    Grade = model.Grade
                }
            );

            student.Grades.Add(new GradeModel
            {
                Grade = model.Grade
            });

            if(_studentsService.UpdateStudent(student))
            {
                _studentsService.SaveChanges();
                return student;
            }

            return null;
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
    }
}