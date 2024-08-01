using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService iCarImageService)
        {
            _carImageService = iCarImageService;
        }

        [HttpPost("Add")]
        public IActionResult AddImage([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.AddCarImage(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("Multiadd")]
        public IActionResult AddImages([FromForm] int CarId, [FromForm] params IFormFile[] files)
        {

            foreach (var file in files)
            {
                var result = _carImageService.AddCarImage(file, new CarImage { CarId = CarId });
                if (!result.Success)
                {
                    return BadRequest(result);
                }

            }
            return Ok(Messages.Added);

        }

        [HttpPost("Update")]
        public IActionResult UpdateImage([FromForm] IFormFile file, [FromForm]CarImage carImage)
        {
            var result = _carImageService.UpdateCarImage(file, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteImage([FromForm] params int[] CarImageIds)
        {
            foreach (var id in CarImageIds)
            {
                var result = _carImageService.DeleteCarImage(id);
                if (!result.Success)
                {
                    return BadRequest(result);
                }
            }
            return Ok(Messages.Deleted);
        }  //carId de eklenebilirdi.

        [HttpGet("GetByCarId")]
        public IActionResult GetByCarId(int CarId)
        {
            var result = _carImageService.GetByCarId(CarId);
            if (!result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCars()
        {
            var result = _carImageService.GetAllCarImage();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetCarImagesById(int id)
        {
            var result = _carImageService.GetCarImageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
