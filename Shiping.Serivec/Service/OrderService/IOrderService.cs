using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Data.Entities;
using Shipping.Service.DTOS.Order;

namespace Shipping.Service.Service.OrderService
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(OrderCreateDto orderCreateDto);
        Task UpdateOrderAsync(int id, OrderUpdateDto orderUpdateDto);
        Task DeleteOrderAsync(int id);
    }
}
