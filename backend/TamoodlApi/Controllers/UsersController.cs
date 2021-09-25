using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TamoodlApi.Data.Accounts;
using TamoodlApi.Models;

namespace TamoodlApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(TokenRequestModel model)
        {
            var authToken = await _userService.GetTokenAsync(model);

            if(authToken == null)
            {
                return BadRequest();
            }

            return Ok(authToken);
        }

        // [Authorize(Roles = "Teacher,Admin")]
        [HttpPost("create/student")]
        public async Task<ActionResult<string>> Register(RegisterStudentModel model)
        {
            if(await _userService.CreateStudent(model))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}