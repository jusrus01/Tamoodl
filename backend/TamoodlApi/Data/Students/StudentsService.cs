using System.Threading.Tasks;
using TamoodlApi.Data.Contexts;
using TamoodlApi.Models;
using System.Linq;

namespace TamoodlApi.Data.Students
{
    public class StudentsService : IStudentsService
    {
        private readonly DataDbContext _context;

        public StudentsService(DataDbContext context)
        {
            _context = context;
        }
        public StudentModel FindStudentByEmail(string email)
        {
            return _context.Students.Where(student => student.Email == email).FirstOrDefault();
        }
    }
}