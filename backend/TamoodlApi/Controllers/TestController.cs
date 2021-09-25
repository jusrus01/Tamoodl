using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Primitives;
using TamoodlApi.Authentication;
using TamoodlApi.Data.Courses;

namespace TamoodlApi.Controllers
{
    // [Authorize]
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private ICoursesService _coursesService;

        public TestController(UserManager<IdentityUser> userManager, ICoursesService courseService)
        {
            _userManager = userManager;
            _coursesService = courseService;
        }

        [HttpGet("course")]
        public ActionResult GetTestCourse()
        {
            return Ok(_coursesService.FindCourseByName("Math"));
        } 

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityUser>>> Index()
        {
            // return Ok(_userManager.Users.ToList());
            StringValues values;
            Request.Headers.TryGetValue("Authorization", out values);
            string token = values[0].Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[1];
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var to = handler.ReadToken(token) as JwtSecurityToken;

            return Ok(to);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public ActionResult GetAll()
        {
            return Ok(_userManager.Users.ToList());
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("t")]
        public ActionResult Test()
        {
            return Ok("hello world");
        }
    }
}