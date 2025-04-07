using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Delivery;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public DeliveryController(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryReadDto>>> GetAll()
        {
            var deliveries = await _unitOfWork.GetRepository<Delivery, string>().GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DeliveryReadDto>>(deliveries));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryReadDto>> GetById(string id)
        {
            var delivery = await _unitOfWork.GetRepository<Delivery, string>().GetByIdAsync(id);
            if (delivery == null) return NotFound();

            return Ok(_mapper.Map<DeliveryReadDto>(delivery));
        }

        [HttpPost]
        public async Task<ActionResult> Create(DeliveryCreateDto dto)
        {
            var delivery = _mapper.Map<Delivery>(dto);
            await _unitOfWork.GetRepository<Delivery, string>().AddAsync(delivery);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetById), new { id = delivery.UserId }, _mapper.Map<DeliveryReadDto>(delivery));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, DeliveryUpdateDto dto)
        {
            var repo = _unitOfWork.GetRepository<Delivery, string>();
            var delivery = await repo.GetByIdAsync(id);
            if (delivery == null) return NotFound();

            _mapper.Map(dto, delivery);
            await repo.UpdateAsync(delivery);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var repo = _unitOfWork.GetRepository<Delivery, string>();
            var delivery = await repo.GetByIdAsync(id);
            if (delivery == null) return NotFound();

            await repo.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

    }
}
