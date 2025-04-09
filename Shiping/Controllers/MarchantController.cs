using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Marchant;
using Shipping.Service.Service.MarchantService;

namespace Shipping.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarchantController : ControllerBase
    {
        private readonly IMarchantService _marchantService;

        public MarchantController(IMarchantService marchantService)
        {
            _marchantService = marchantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _marchantService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _marchantService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMarchantDto dto)
        {
            await _marchantService.CreateAsync(dto);
            return Ok("Marchant created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateMarchantDto dto)
        {
            var updated = await _marchantService.UpdateAsync(id, dto);
            if (!updated) return NotFound();
            return Ok("Marchant updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _marchantService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}
