// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using TamoodlApi.Data.Students;
// using TamoodlApi.Models;

// namespace TamoodlApi.Controllers
// {
//     // [Authorize(Roles = "Teacher,Admin")]
//     [Route("api/students")]
//     [ApiController]
//     public class StudentsController : Controller
//     {
//         private readonly IStudentsService _studentsService;

//         public StudentsController(IStudentsService studentsService)
//         {
//             _studentsService = studentsService;
//         }

//         [HttpPost("addModule")]
//         public ActionResult AddModule(CourseCreationModel model)
//         {
//             var currentStudent = _studentsService.FindStudentByEmail(model.Email);

//             if(currentStudent == null)
//             {
//                 return NotFound();
//             }

//             // if(currentStudent.Courses.ContainsKey(newModule))
//             // {
//             //     return BadRequest();
//             // }

//             // currentStudent.Modules.Add(newModule, new List<byte>());

//             if(_studentsService.AddCourse(currentStudent, model.Course))
//             {
//                 return Ok();
//             }

//             return BadRequest();
//         }

//         [HttpPut("addGradeToModule")]
//         public ActionResult AddGradeToModule(string email, string module, byte grade)
//         {
//             var currentStudent = _studentsService.FindStudentByEmail(email);

//             if(currentStudent == null)
//             {
//                 return NotFound();
//             }

//             if(_studentsService.AddGrade(currentStudent, module, grade))
//             {
//                 return Ok();
//             }

//             return BadRequest();
//         }
//     }
// }