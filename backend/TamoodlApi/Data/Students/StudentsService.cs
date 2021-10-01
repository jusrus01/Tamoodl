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

        public async Task<StudentModel> AddStudent(StudentModel newStudent)
        {
            if(FindStudent(newStudent) == null)
            {
                await _context.AddAsync(newStudent);
                return newStudent;
            }

            return null;
        }

        public StudentModel FindStudent(StudentModel student)
        {
            return _context.Students.Where(s => 
                s.CourseName == student.CourseName &&
                s.Email == student.Email).FirstOrDefault();
        }

        public StudentModel FindStudent(string courseName, string studentEmail)
        {
            return _context.Students.Where(s =>
                s.CourseName == courseName &&
                s.Email == studentEmail).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool UpdateStudent(StudentModel student)
        {
            if(student == null)
            {
                return false;
            }

            _context.Students.Update(student);
            return true;
        }
    }
}