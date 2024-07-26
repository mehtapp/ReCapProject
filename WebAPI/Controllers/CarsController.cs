using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("Getall")]
        public IActionResult GetCars()
        {
            var result = _carService.GetCars();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpPost("Addcar")]
        public IActionResult AddCar(Car car) 
        {
            var result = _carService.AddCar(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }

        [HttpGet("Getcarbyid")]
        public IActionResult GetCarById(int id)
        {
            var result = _carService.GetCarById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletecar")]
        public IActionResult DeleteCar(Car car)
        {
            var result = _carService.DeleteCar(car);
            if(result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }

        [HttpPost("Updatecar")]
        public IActionResult UpdateCar(Car car)
        {
         var result = _carService.UpdateCar(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Getcarsbycolourid")]
        public IActionResult GetCarsByColourId(int id)
        {
            var result = _carService.GetCarsByColourId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
