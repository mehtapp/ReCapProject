using Business.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IAuthService authService;

        public AuthsController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public IActionResult register()
        {
            return Ok();
        }

        [HttpGet("login")]
        public IActionResult login()
        {
            return Ok();
        }

        [HttpGet("createToken")]
        public IActionResult createToken()
        {
            return BadRequest();
        }

        [HttpGet("userExist")]
        public IActionResult userExist()
        {
            return Ok();
        }
    }
}
