using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Branch;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchController(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchReadDto>>> GetBranches()
        {
            var branches = await _unitOfWork.GetRepository<Branch, int>().GetAllAsync();
            var result = branches.Where(b => !b.IsDeleted).ToList();
            return Ok(_mapper.Map<IEnumerable<BranchReadDto>>(result));
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchReadDto>> GetBranch(int id)
        {
            var branch = await _unitOfWork.GetRepository<Branch, int>().GetByIdAsync(id);

            if (branch == null || branch.IsDeleted)
                return NotFound();

            return Ok(_mapper.Map<BranchReadDto>(branch));
        }

         
        [HttpPost]
        public async Task<ActionResult> CreateBranch(BranchCreateDto dto)
        {
            var branch = _mapper.Map<Branch>(dto);
            branch.IsDeleted = false;

            await _unitOfWork.GetRepository<Branch, int>().AddAsync(branch);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetBranch), new { id = branch.Bid }, _mapper.Map<BranchReadDto>(branch));
        }

         
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(int id, BranchUpdateDto dto)
        {
            if (id != dto.Bid)
                return BadRequest();

            var repo = _unitOfWork.GetRepository<Branch, int>();
            var existingBranch = await repo.GetByIdAsync(id);

            if (existingBranch == null || existingBranch.IsDeleted)
                return NotFound();

            _mapper.Map(dto, existingBranch);
            await repo.UpdateAsync(existingBranch);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

         
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var repo = _unitOfWork.GetRepository<Branch, int>();
            var branch = await repo.GetByIdAsync(id);

            if (branch == null || branch.IsDeleted)
                return NotFound();

            branch.IsDeleted = true;
            await repo.UpdateAsync(branch);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }

}
