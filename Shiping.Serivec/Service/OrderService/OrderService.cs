using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Order;

namespace Shipping.Service.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            return await repo.GetAllAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            return await repo.GetByIdAsync(id);
        }

        public async Task CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            var order = _mapper.Map<Order>(orderCreateDto);
            var repo = _unitOfWork.GetRepository<Order, int>();
            await repo.AddAsync(order);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto)
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            var order = await repo.GetByIdAsync(id);
            if (order == null) throw new Exception("Order not found");

            _mapper.Map(orderUpdateDto, order);
            await repo.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            var order = await repo.GetByIdAsync(id);
            if (order == null) throw new Exception("Order not found");

            order.IsDeleted = true;
            await repo.UpdateAsync(order);
            await _unitOfWork.CompleteAsync();
        }
    }
}
