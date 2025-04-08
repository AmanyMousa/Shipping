using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Delivery;
using Shipping.Service.Service.DeliveryService;

namespace Shipping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryReadDto>>> GetAll()
        {
            var deliveries = await _deliveryService.GetAllAsync();
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryReadDto>> GetById(string id)
        {
            var delivery = await _deliveryService.GetByIdAsync(id);
            if (delivery == null) return NotFound();

            return Ok(delivery);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DeliveryCreateDto dto)
        {
            var result = await _deliveryService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.UserId }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, DeliveryUpdateDto dto)
        {
            var updated = await _deliveryService.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var deleted = await _deliveryService.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }

}
