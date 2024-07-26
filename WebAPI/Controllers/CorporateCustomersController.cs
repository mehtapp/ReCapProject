using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateCustomersController : ControllerBase
    {
        [HttpGet("GetallCorporateCustomer")]
        public IActionResult GetAllCorporateCustomer()
        {
            return Ok();

        }

        [HttpPost("Addcorporatecustomer")]
        public IActionResult AddCorporateCustomer(User user , CorporateCustomer customer)
        {
            return Ok();
        }

        [HttpPost("Deletecorporatecustomer")]
        public IActionResult DeleteCorporateCustomer(User user, CorporateCustomer customer)
        {
            return Ok();
        }
    }
}
