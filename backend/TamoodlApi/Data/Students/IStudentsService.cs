using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Students
{
    public interface IStudentsService
    {
        StudentModel FindStudentByEmail(string email);
    }
}