using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Repostory.Repostories;
using Shipping.Service.DTOS.OrdersDTOS;
using Shipping.Service.OrdetService;

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
        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var orders = await _unitOfWork.GetRepository<Order,int>().GetAllAsync();
            var result = orders.Where(b => !b.IsDeleted).ToList();

            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(result);
            return Ok(orderDtos);
        }
        // GET: api/orders/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            var order = await _unitOfWork.GetRepository<Order, int>().GetByIdAsync(id);
            if (order == null|| order.IsDeleted)
            {
                return NotFound();
            }
            var orders = _mapper.Map<OrderDto>(order);
            return Ok(orders);
        }
      
        // POST: api/orders
        [HttpPost]
      public async Task<ActionResult> CreateOrder( OrderDto orders)
        {
            // في ايرور هنا عشان خاطر userid
            if (orders == null)
            {
                return BadRequest();
            }
            var orderd = _mapper.Map<Order>(orders);
            orderd.IsDeleted = false;
            await _unitOfWork.GetRepository<Order, int>().AddAsync(orderd);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetOrderById), new { id = orders.Id }, _mapper.Map<OrderDto>(orders));
        }
        

        // GET: api/orders/type/{type}
        //[HttpGet("type/{type}")]
        //public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByType(Order.OrderTypeEnum type)
        //{
        //    var orders = await .GetOrdersByTypeAsync(type);
        //    var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
        //    return Ok(orderDtos);
        //}

    }
}
