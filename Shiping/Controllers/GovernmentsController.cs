using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Service.DTOS.GovermentDTOS;
using Shipping.Service.Governemt;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentsController : ControllerBase
    {
        private readonly IGovernmentService _governmentService;

        public GovernmentsController(IGovernmentService governmentService)
        {
            _governmentService = governmentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GovernmentDTO>>> GetAll()
        {
            var governments = await _governmentService.GetAllGovernmentsAsync();
            return Ok(governments);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GovernmentDTO>> GetById(int id)
        {
            var government = await _governmentService.GetGovernmentByIdAsync(id);
            if (government == null)
                return NotFound();

            return Ok(government);
        }
        [HttpPost]
        public async Task<IActionResult> Add(GovernmentDTO governmentDto)
        {
            await _governmentService.AddGovernmentAsync(governmentDto);
            return CreatedAtAction(nameof(GetById), new { id = governmentDto.Id }, governmentDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GovernmentDTO governmentDto)
        {
            if (id != governmentDto.Id)
                return BadRequest("ID mismatch");

            var result = await _governmentService.UpdateGovernmentAsync(id, governmentDto);
            if (!result)
                return NotFound();

            return NoContent();
        }
        [HttpGet("by-status/{status}")]
        public async Task<ActionResult<IEnumerable<GovernmentDTO>>> GetByStatus(string status)
        {
            var governments = await _governmentService.GetGovernmentsByStatusAsync(status);
            return Ok(governments);
        }
    }
}
