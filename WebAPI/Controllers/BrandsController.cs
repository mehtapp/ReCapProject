using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("Getall")]
        public IActionResult GetBrands()
        {
            var result = _brandService.GetBrands();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("Addbrand")]
        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.AddBrand(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("Getbrandbyid")]
        public IActionResult GetBrandById(int id)
        {
            var result = _brandService.GetBrandById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
            
        }

        [HttpPost("Deletebrand")]
        public IActionResult DeleteBrand(Brand brand)
        {
            var result = _brandService.DeleteBrand(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result); 
        }

        [HttpPost("Updatebrand")]
        public IActionResult UpdateBrand(Brand brand)
        {
            var result = _brandService.UpdateBrand(brand);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }







    }
}
