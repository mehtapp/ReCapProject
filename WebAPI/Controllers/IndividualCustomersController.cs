using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public IActionResult AddIndividualCustomer(IndividualCustomerWithUserInfoDto customer)
        {
            return Ok();
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
        public IActionResult DeleteIndividualCustomer(IndividualCustomerWithUserInfoDto customer)
        {
            return Ok();
        }

    }
}
