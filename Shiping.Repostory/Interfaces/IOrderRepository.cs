using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{

    public interface IOrderRepository : IGenericRepo<Order, int>
    {
        Task<IEnumerable<Order>> GetOrdersWithDetailsAsync();
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);

        Task<IEnumerable<Order>> GetOrdersByTypeAsync(Order.OrderTypeEnum orderType);

    }

}
