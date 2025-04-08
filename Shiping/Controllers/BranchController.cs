using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Branch;
using Shipping.Service.Service.BranchService;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchReadDto>>> GetBranches()
        {
            return Ok(await _branchService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchReadDto>> GetBranch(int id)
        {
            var branch = await _branchService.GetByIdAsync(id);
            if (branch == null) return NotFound();
            return Ok(branch);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBranch(BranchCreateDto dto)
        {
            var created = await _branchService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetBranch), new { id = created.Bid }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, BranchUpdateDto dto)
        {
            var updated = await _branchService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var deleted = await _branchService.SoftDeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}
