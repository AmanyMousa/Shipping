using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.RejectionOrder;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RejectionOrderController : ControllerBase
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public RejectionOrderController(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRejectionOrderDto>>> GetAll()
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var data = await repo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetRejectionOrderDto>>(data);
            return Ok(result);
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRejectionOrderDto>> GetById(int id)
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var rejection = await repo.GetByIdAsync(id);
            if (rejection == null || rejection.IsDeleted) return NotFound();

            var dto = _mapper.Map<GetRejectionOrderDto>(rejection);
            return Ok(dto);
        }

         
        [HttpPost]
        public async Task<ActionResult> Create(CreateRejectionOrderDto dto)
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var entity = _mapper.Map<RejectionOrder>(dto);
            await repo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return Ok("Rejection order created successfully.");
        }

         
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateRejectionOrderDto dto)
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null || entity.IsDeleted) return NotFound();

            _mapper.Map(dto, entity);
            await repo.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
            return Ok("Rejection order updated successfully.");
        }

         
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null || entity.IsDeleted) return NotFound();

            entity.IsDeleted = true;  
            await repo.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }

}
