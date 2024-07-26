using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("Getallrentedcars")]
        public IActionResult GetAllRentedCars()
        {
            var result = _rentalService.GetAllRentedCars();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Addrentedcar")]
        public IActionResult AddtRentedCars(Rental rental)
        {
            var result = _rentalService.AddRentedCar(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Getrentedcarbyid")]
        public IActionResult GetRentedCarById(int id)
        {
            var result = _rentalService.GetRentedCarById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Deleterentedcar")]
        public IActionResult DeleteRentedCar(Rental rental)
        {
            var result = _rentalService.DeleteRentedCar(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Updaterentedcar")]
        public IActionResult UpdateRentedCar(Rental rental)
        {
            var result = _rentalService.UpdateRentedCar(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Deliveracarback")]
        public IActionResult DeliverACarBack(Rental rental)
        {
            var result = _rentalService.DeliverACarBack(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
