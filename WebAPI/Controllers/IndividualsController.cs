using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualsController : ControllerBase
    {

        IIndividualCustomerService _customerService;

        public IndividualsController(IIndividualCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Addindividualcustomer")]
        public IActionResult AddIndividualCustomer(User user ,IndividualCustomer customer)
        {
            var result = _customerService.AddIndividualCustomer(user, customer);
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
        public IActionResult DeleteIndividualCustomer(User user , IndividualCustomer customer) 
        { 
            var result = _customerService.DeleteIndividualCustomer(user, customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
    }
}
