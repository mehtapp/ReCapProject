using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateCustomersController : ControllerBase
    {
        ICorporateCustomerService _corporateCustomerService;

        public CorporateCustomersController(ICorporateCustomerService corporateCustomerService)
        {
            _corporateCustomerService = corporateCustomerService;
        }

        [HttpGet("Getallcorporatecustomer")]
        public IActionResult GetAllCorporateCustomer()
        {
            var result = _corporateCustomerService.GetAllCorporateCustomer();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }

        [HttpPost("Addcorporatecustomer")]
        public IActionResult AddCorporateCustomer(CorporateCustomerWithUserInfoDto customer)
        {
            User user = new User();
            CorporateCustomer corporateCustomer = new CorporateCustomer();
            user.UserName = customer.UserName;
            user.Email = customer.Email;

            //user.Password = customer.Password;
            corporateCustomer.CompanyName = customer.CorporateName;
            var result = _corporateCustomerService.AddCorporateCustomer(user, corporateCustomer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("Deletecorporatecustomer")]
        public IActionResult DeleteCorporateCustomer(CorporateCustomerWithUserInfoDto customer)
        {
            User user = new User();
            CorporateCustomer corporateCustomer = new CorporateCustomer();
            user.UserName = customer.UserName;
            user.Email = customer.Email;
            user.UserId = customer.UserId;
            corporateCustomer.UserId = customer.UserId;
            corporateCustomer.CorporateId = customer.CorporateCustomerId;
            //user.Password = customer.Password;
            corporateCustomer.CompanyName = customer.CorporateName;

            var result = _corporateCustomerService.DeleteCorporateCustomer(user, corporateCustomer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
