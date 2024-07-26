using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoursController : ControllerBase
    {
        IColourService _colorService;

        public ColoursController(IColourService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetColors();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("AddColour")]
        public IActionResult AddColour(Colour colour)
        {
            var result = _colorService.AddColour(colour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("Getcolourbyid")]
        public IActionResult GetColourById(int id)
        {
            IDataResult<Colour> result = _colorService.GetColourById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("DeleteColour")]
        public IActionResult DeleteColour(Colour colour) 
        {
                var result = _colorService.DeleteColour(colour);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
        }

        [HttpPost("Updatecolour")]
        public IActionResult UpdateColour(Colour colour)
        {
            var result = _colorService.UpdateColour(colour);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }





    }
}
