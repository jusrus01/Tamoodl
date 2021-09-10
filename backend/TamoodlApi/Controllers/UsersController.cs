using System.Threading.Tasks;
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
            var item = await _userService.GetTokenAsync(model);

            if(item == null)
            {
                return BadRequest();
            }

            return Ok(item);
        }
    }
}