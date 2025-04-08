using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.RejectionOrder;
using Shipping.Service.Service.RejectionOrderService;

namespace Shipping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RejectionOrderController : ControllerBase
    {
        private readonly IRejectionOrderService _rejectionOrderService;

        public RejectionOrderController(IRejectionOrderService rejectionOrderService)
        {
            _rejectionOrderService = rejectionOrderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRejectionOrderDto>>> GetAll()
        {
            var result = await _rejectionOrderService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRejectionOrderDto>> GetById(int id)
        {
            var result = await _rejectionOrderService.GetByIdAsync(id);
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateRejectionOrderDto dto)
        {
            var success = await _rejectionOrderService.CreateAsync(dto);
            if (!success) return BadRequest("Creation failed.");

            return Ok("Rejection order created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateRejectionOrderDto dto)
        {
            var success = await _rejectionOrderService.UpdateAsync(id, dto);
            if (!success) return NotFound();

            return Ok("Rejection order updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _rejectionOrderService.SoftDeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }


}
