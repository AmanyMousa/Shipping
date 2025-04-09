using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Service.DTOS.WightPriceDTO;
using Shipping.Service.WighPrice;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightPricesController : ControllerBase
    {
        private readonly IWeightPriceService _weightPriceService;

        public WeightPricesController(IWeightPriceService weightPriceService)
        {
            _weightPriceService = weightPriceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var weightPrices = await _weightPriceService.GetAllAsync();
                return Ok(weightPrices);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var weightPrice = await _weightPriceService.GetByIdAsync(id);
                return weightPrice != null ? Ok(weightPrice) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(WeightPriceDTO weightPriceDto)
        {
            await _weightPriceService.AddAsync(weightPriceDto);
            return CreatedAtAction(nameof(GetById), new { id = weightPriceDto.Id }, weightPriceDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, WeightPriceDTO weightPriceDto)
        {
            try
            {
                if (id != weightPriceDto.Id)
                    return BadRequest("ID mismatch");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _weightPriceService.UpdateAsync(id, weightPriceDto);
                return result ? NoContent() : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _weightPriceService.DeleteAsync(id);

                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        //[HttpGet("search")]
        //public async Task<IActionResult> Search([FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        //{
        //    try
        //    {
        //        var results = await _weightPriceService.SearchAsync(minPrice, maxPrice);
        //        return Ok(results);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
