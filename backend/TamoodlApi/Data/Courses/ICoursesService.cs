using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Courses
{
    public interface ICoursesService
    {
        Task<bool> CreateCourse(string courseName, string ownerEmail);
        void SaveChanges();

        CourseModel FindCourseByName(string courseName);
    }
}