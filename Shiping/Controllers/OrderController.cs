<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Order;
using Shipping.Service.DTOS.Branch;

using AutoMapper;
=======
﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Repostory.Repostories;
using Shipping.Service.DTOS.OrdersDTOS;
using Shipping.Service.OrdetService;
>>>>>>> a5dbc68d37e694ad3f447273559942ac2ebd434b

namespace Shipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
<<<<<<< HEAD
=======

>>>>>>> a5dbc68d37e694ad3f447273559942ac2ebd434b
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderController(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
<<<<<<< HEAD

        
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
=======
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

>>>>>>> a5dbc68d37e694ad3f447273559942ac2ebd434b
    }
}
