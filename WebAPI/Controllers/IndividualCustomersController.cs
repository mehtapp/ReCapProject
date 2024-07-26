using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomersController : ControllerBase
    {

        IIndividualCustomerService _customerService;

        public IndividualCustomersController(IIndividualCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Addindividualcustomer")]
        public IActionResult AddIndividualCustomer(IndividualCustomerWithUserInfo customer)
        {
            User user = new User();
            IndividualCustomer individualCustomer = new IndividualCustomer();
            user.UserName = customer.UserName;
            user.Email = customer.Email;
            user.Password = customer.Password;
            individualCustomer.FirstName = customer.FirstName;
            individualCustomer.LastName = customer.LastName;

            var result = _customerService.AddIndividualCustomer(user, individualCustomer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Getallindividualcustomer")]
        public IActionResult GetAllIndividualCustomer()
        {
            var result = _customerService.GetAllIndividualCustomer();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Deleteindividualcustomer")]
        public IActionResult DeleteIndividualCustomer(IndividualCustomerWithUserInfo customer)
        {
            User user = new User();
            IndividualCustomer individualCustomer = new IndividualCustomer();
            user.UserName = customer.UserName;
            user.Email = customer.Email;
            user.Password = customer.Password;
            individualCustomer.UserId = customer.UserId;
            user.UserId = customer.UserId;
            individualCustomer.IndividualCustomerId = customer.IndividualCustomerId;
            individualCustomer.FirstName = customer.FirstName;
            individualCustomer.LastName = customer.LastName;

            var result = _customerService.DeleteIndividualCustomer(user, individualCustomer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
