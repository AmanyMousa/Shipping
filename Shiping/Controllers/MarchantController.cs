using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Marchant;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarchantController : ControllerBase
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public MarchantController(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

         
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMarchantDto>>> GetAll()
        {
            var repo = _unitOfWork.GetRepository<Marchant, string>();
            var marchants = await repo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetMarchantDto>>(marchants);
            return Ok(result);
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<GetMarchantDto>> GetById(string id)
        {
            var repo = _unitOfWork.GetRepository<Marchant, string>();
            var marchant = await repo.GetByIdAsync(id);
            if (marchant == null) return NotFound();

            var dto = _mapper.Map<GetMarchantDto>(marchant);
            return Ok(dto);
        }

         
        [HttpPost]
        public async Task<ActionResult> Create(CreateMarchantDto dto)
        {
            var repo = _unitOfWork.GetRepository<Marchant, string>();
            var entity = _mapper.Map<Marchant>(dto);
            await repo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return Ok("Marchant created successfully.");
        }

         
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateMarchantDto dto)
        {
            var repo = _unitOfWork.GetRepository<Marchant, string>();
            var marchant = await repo.GetByIdAsync(id);
            if (marchant == null) return NotFound();

            _mapper.Map(dto, marchant);
            await repo.UpdateAsync(marchant);
            await _unitOfWork.CompleteAsync();
            return Ok("Marchant updated successfully.");
        }

         
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var repo = _unitOfWork.GetRepository<Marchant, string>();
            var marchant = await repo.GetByIdAsync(id);
            if (marchant == null) return NotFound();

            await repo.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
