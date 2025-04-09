using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Order;
using Shipping.Service.DTOS.Branch;

using AutoMapper;

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> GetAllOrders()
        {
            var orders = await _unitOfWork.GetRepository<Order, int>().GetAllAsync();
            var orderDtos = _mapper.Map<IEnumerable<OrderReadDto>>(orders);
            return Ok(orderDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReadDto>> GetOrderById(int id)
        {
            var order = await _unitOfWork.GetRepository<Order, int>().GetByIdAsync(id);
            if (order == null)
                return NotFound();

            var orderDto = _mapper.Map<OrderReadDto>(order);
            return Ok(orderDto);
        }


        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderCreateDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await _unitOfWork.GetRepository<Order, int>().AddAsync(order);
            await _unitOfWork.CompleteAsync();

            var orderDto = _mapper.Map<OrderReadDto>(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, orderDto);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, OrderUpdateDto dto)
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            var order = await repo.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            _mapper.Map(dto, order);
            await repo.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();

            return Ok("Order updated successfully.");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            var order = await repo.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            order.IsDeleted = true;
            await repo.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}