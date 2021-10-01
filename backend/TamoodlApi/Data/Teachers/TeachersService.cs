using System.Threading.Tasks;
using TamoodlApi.Data.Contexts;
using System.Linq;
using TamoodlApi.Models;
using System;
using TamoodlApi.Data.Courses;
using TamoodlApi.Data.Students;
using System.Collections.Generic;
using TamoodlApi.Dtos;

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
        public async Task<StudentModel> AddGrade(AddGradeModel model)
        {
            var student = _studentsService.FindStudent(model.CourseName, model.StudentEmail);

            if(student == null)
            {
                return null;
            }

            var newGrade = new GradeModel
            {
                CourseName = model.CourseName,
                StudentEmail = model.StudentEmail,
                Grade = model.Grade,
                Date = DateTime.Now.ToLongDateString()
            };

            // adding new grade to database
            await _context.Grades.AddAsync(newGrade);
            _studentsService.SaveChanges();

            // fetching all grades and returning it to user
            student.Grades = _context.Grades.Where(grade =>
                grade.CourseName == student.CourseName &&
                grade.StudentEmail == student.Email)
                .Select(g => new GradeReadDto { Grade = g.Grade, Date = g.Date, CourseName = g.CourseName })
                .ToList();

            return student;
        }

        public GradeReadDto RemoveGrade(string date, StudentModel student)
        {
            var grade = _context.Grades.Where(g => 
                g.CourseName == student.CourseName &&
                g.StudentEmail == student.Email &&
                g.Date == date).FirstOrDefault();

            if(grade == null)
            {
                return null;
            }
            
            _context.Grades.Remove(grade);

            return new GradeReadDto { Date = grade.Date, CourseName = grade.CourseName, Grade = grade.Grade };
        }

        // public Task<bool> RemoveGrade(CourseModel currentCourse, StudentModel student, byte grade)
        // {
        //     throw new System.NotImplementedException();
        // }

        // public Task<bool> RemoveStudent(StudentModel model)
        // {
        //     throw new System.NotImplementedException();
        // }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}