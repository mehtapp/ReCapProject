using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterForIndividualCustomerDto userRegisterForIndividualCustomer)
        {
            var userExist = _authService.UserExist(userRegisterForIndividualCustomer.Email);
            if (userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var result = _authService.Register(userRegisterForIndividualCustomer);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            //Token üret
            var tokenResult = _authService.CreateAccessToken(new User
            {
                UserId = result.Data.UserId,
                Email = result.Data.Email,
                UserName = result.Data.UserName
            });

            return Ok(tokenResult);
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            //Böyle bir kullanıcı var mı
            //Vrsa tokın üret
            return Ok();
        }
    }
}
