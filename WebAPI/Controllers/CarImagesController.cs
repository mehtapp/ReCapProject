using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _iCarImageService;

        public CarImagesController(ICarImageService iCarImageService)
        {
            _iCarImageService = iCarImageService;
        }

        [HttpPost("Add")]
        public IActionResult AddImage(CarImage carImage)
        {
            var result = _iCarImageService.AddCarImage(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
           
        }

        [HttpPost("Update")]
        public IActionResult UpdateImage(CarImage carImage)
        {
            var result = _iCarImageService.UpdateCarImage(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteImage(CarImage carImage)
        {
            var result = _iCarImageService.DeleteCarImage(carImage);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCars()
        {
            var result = _iCarImageService.GetAllCarImage();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetCarImagesById(int id)
        {
            var result = _iCarImageService.GetCarImageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
