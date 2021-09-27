using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Teachers
{
    public interface ITeachersService
    {
        Task<bool> CreateCourse(CourseModel model);
        Task<bool> AddStudent(StudentModel model);
        Task<bool> RemoveStudent(StudentModel model);
        Task<CourseModel> ViewCourse(string courseName);
        Task<bool> AddGrade(CourseModel currentCourse, StudentModel student, byte grade);
        Task<bool> RemoveGrade(CourseModel currentCourse, StudentModel student, byte grade);
        Task<bool> UpdateGrade(CourseModel currentCourse, StudentModel student, byte grade);
        void SaveChanges();
    }
}