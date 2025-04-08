using Microsoft.AspNetCore.Mvc;
using Shipping.Service.DTOS.CityDTO;
using System;
using System.Threading.Tasks;

namespace Shipping.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        //private readonly ILogger<CityController> _logger;

        public CityController(
            ICityService cityService,
            ILogger<CityController> logger)
        {
            _cityService = cityService;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = await _cityService.GetAllCitiesAsync();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error retrieving all cities");
                return StatusCode(500, "Internal server error");
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCityById(int id)
        //{
        //    try
        //    {
        //        var city = await _cityService.GetCityByIdAsync(id);

        //        if (city == null)
        //        {
        //            return NotFound($"City with ID {id} not found");
        //        }

        //        return Ok(city);
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogError(ex, $"Error retrieving city with ID {id}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CityDto cityDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdCity = await _cityService.CreateCityAsync(cityDto);
                return Created(
                    "",
                    createdCity);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Error creating city");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] CityDto cityDto)
        {
            try
            {
                if (id != cityDto.Cid)
                {
                    return BadRequest("ID in route doesn't match ID in body");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _cityService.UpdateCityAsync(id, cityDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error updating city with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                await _cityService.DeleteCityAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, $"Error deleting city with ID {id}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}