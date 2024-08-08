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
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {

            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }
            var token = _authService.CreateAccessToken(userToLogin.Data);
            if (!token.Success)
            {
                return BadRequest(token);
            }
            return Ok(token);
        }
    }
}
