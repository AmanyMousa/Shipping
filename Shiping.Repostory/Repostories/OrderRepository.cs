using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Repostories
{
    public class OrderRepository : GenricRepo<Order, int>, IOrderRepository
    {
        private readonly ShippingDbContext _context;

        public OrderRepository(ShippingDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                                 .Where(o => o.UserId == userId.ToString()) 
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersWithDetailsAsync()
        {
            return await _context.Orders
                .Include(o => o.Branch)
                .Include(o => o.Gov)
                .Include(o => o.City)
                .Include(o => o.ShippingType)
                .Include(o => o.User)
                .Include(o => o.RejectionOrders)
                .Include(o => o.ProdOrders)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByTypeAsync(Order.OrderTypeEnum orderType)
        {
            return await _context.Orders
                .Where(o => o.OrderType == orderType)
                .ToListAsync();
        }
    }
}
