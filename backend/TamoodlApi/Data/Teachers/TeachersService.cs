using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Teachers
{
    public class TeachersService : ITeachersService
    {
        public Task<bool> AddGrade(CourseModel currentCourse, StudentModel student, byte grade)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddStudent(StudentModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateCourse(CourseModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveGrade(CourseModel currentCourse, StudentModel student, byte grade)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveStudent(StudentModel model)
        {
            throw new System.NotImplementedException();
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