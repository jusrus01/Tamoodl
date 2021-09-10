using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

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
            return Ok(_userManager.Users.ToList());
        }
    }
}