using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Primitives;
using TamoodlApi.Authentication;

namespace TamoodlApi.Controllers
{
    [Authorize]
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public TestController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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

        [Authorize(Roles = "Teacher")]
        [HttpGet("t")]
        public ActionResult Test()
        {
            return Ok("hello world");
        }
    }
}