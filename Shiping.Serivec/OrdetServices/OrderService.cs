using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.OrdetService
{
    public class OrderService : IOrderService
        {
            private readonly IUnitofwork _unitOfWork;

            public OrderService(IUnitofwork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IEnumerable<Order>> GetAllOrdersAsync()
            {
                return await _unitOfWork.Orders.GetOrdersWithDetailsAsync();
            }

            public async Task<Order> GetOrderByIdAsync(int id)
            {
                return await _unitOfWork.Orders.GetByIdAsync(id);
            }

            public async Task AddOrderAsync(Order order)
            {
                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.CompleteAsync();
            }

            public async Task<IEnumerable<Order>> GetOrdersByTypeAsync(Order.OrderTypeEnum type)
            {
                return await _unitOfWork.Orders.GetOrdersByTypeAsync(type);
            }
        }
    }



