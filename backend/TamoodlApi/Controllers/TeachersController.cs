using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TamoodlApi.Data.Teachers;

namespace TamoodlApi.Controllers
{
    [Route("api/teacher")]
    public class TeachersController : Controller
    {
        private readonly ITeachersService _teachersService;

        public TeachersController(ITeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        // [HttpPost]
        // public Task<ActionResult> CreateCourse()
        // {
            
        // }
    }
}