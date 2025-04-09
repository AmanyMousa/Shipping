using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Service.DTOS.ShippingTypeDTO;
using Shipping.Service.ShippingTypes;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingTypeController : ControllerBase
    {

            private readonly IShippingTypeServices _shippingTypeService;

            public ShippingTypeController(IShippingTypeServices shippingTypeService)
            {
                _shippingTypeService = shippingTypeService;
            }

            // GET: api/ShippingType
            [HttpGet]
            public async Task<ActionResult<IEnumerable<ShippingTypesDTO>>> GetShippingTypes()
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var shippingTypes = await _shippingTypeService.GetAllShippingTypesAsync();
                return Ok(shippingTypes);
            }

            // GET: api/ShippingType/{id}
            [HttpGet("{id}")]
            public async Task<ActionResult<ShippingTypesDTO>> GetShippingTypeById(int id)
            {
                var shippingType = await _shippingTypeService.GetShippingTypeByIdAsync(id);
                if (shippingType == null)
                {
                    return NotFound();
                }
                return Ok(shippingType);
            }

            // POST: api/ShippingType
            [HttpPost]
            public async Task<ActionResult> AddShippingType(ShippingTypesDTO shippingTypeDto)
            {
                await _shippingTypeService.AddShippingTypeAsync(shippingTypeDto);
                return CreatedAtAction(nameof(GetShippingTypeById), new { id = shippingTypeDto.Id }, shippingTypeDto);
            }

            // PUT: api/ShippingType/{id}
            [HttpPut("{id}")]
            public async Task<ActionResult> UpdateShippingType(int id, UpdateShippingTypesDTO shippingTypeDto)
            {
                await _shippingTypeService.UpdateShippingTypeAsync(id, shippingTypeDto);
            return Ok(shippingTypeDto);
            }

        // DELETE: api/ShippingType/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteShippingType(int id)
        {
            await _shippingTypeService.DeleteShippingTypeAsync(id);
            return NoContent();
        }
    }
    }


