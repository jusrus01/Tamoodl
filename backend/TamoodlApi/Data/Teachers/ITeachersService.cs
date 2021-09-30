using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Teachers
{
    public interface ITeachersService
    {
        Task<bool> CreateCourse(CourseModel model);
        Task<CourseModel> AddStudent(CourseModel course, StudentAddModel model);
        Task<bool> RemoveStudent(StudentModel model);
        CourseModel FindCourseByName(string courseName);
        Task<CourseModel> ViewCourse(string courseName);
        bool AddGrade(AddGradeModel model);
        Task<bool> RemoveGrade(CourseModel currentCourse, StudentModel student, byte grade);
        Task<bool> UpdateGrade(CourseModel currentCourse, StudentModel student, byte grade);
        void SaveChanges();
    }
}