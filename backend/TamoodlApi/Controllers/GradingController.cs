// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using TamoodlApi.Data.Accounts;
// using TamoodlApi.Data.Students;
// using TamoodlApi.Models;

// namespace TamoodlApi.Controllers
// {
//     [ApiController]
//     [Route("api/grades")]
//     public class GradingController : ControllerBase
//     {
//         private readonly IStudentsService _studentsService;

//         public GradingController(IStudentsService studentsService)
//         {
//             _studentsService = studentsService;
//         }

//         [HttpGet]
//         public ActionResult<StudentModel> GetGrades(string email)
//         {
//             var studentData = _studentsService.FindStudentByEmail(email);

//             if(studentData == null)
//             {
//                 return NotFound();
//             }
            
//             return Ok(studentData);
//         }
//     }
// }