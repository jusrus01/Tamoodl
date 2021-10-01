using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Courses
{
    public interface ICoursesService
    {
        // Task<bool> CreateCourse(string courseName, string ownerEmail);
        // void SaveChanges();
        // CourseModel FindCourseByName(string courseName);
        // bool UpdateCourse(CourseModel model);
        // bool UpdateStudent(StudentModel model);
        // Task<bool> AddStudent(StudentModel model);
        Task<CourseModel> AddCourse(CourseModel newCourse);
        CourseModel FindCourse(CourseModel course);
        CourseModel FindCourseByName(string courseName);

        void SaveChanges();
    }
}