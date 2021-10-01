using System.Collections.Generic;
using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Students
{
    public interface IStudentsService
    {
        // Task<StudentModel> ViewGrades(string studentsEmail, string courseName);
        // void ViewCourse();

        Task<StudentModel> AddStudent(StudentModel newStudent);
        StudentModel FindStudent(StudentModel student);
        StudentModel FindStudent(string courseName, string studentEmail);
        bool UpdateStudent(StudentModel student);
        void SaveChanges();
    }
}