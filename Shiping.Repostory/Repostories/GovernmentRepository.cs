using Shipping.Data.Entities;
using Shipping.Data;
using Shipping.Repostory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shipping.Repostory.Repostories
{

    public class GovernmentRepository : IGovernmentRepository
    {
        private readonly ShippingDbContext _context;
        private readonly DbSet<Government> _governments;

        public GovernmentRepository(ShippingDbContext context)
        {
            _context = context;
            _governments = context.Governments;
        }
        public async Task<IEnumerable<Government>> GetGovernmentsByStatusAsync(string status)
        {
            return await _governments
                .Where(g => g.Status.ToLower() == status.ToLower())
                .ToListAsync();
        }
        public async Task<Government> GetByIdAsync(int id)
        {
            return await _governments.FindAsync(id);
        }

        public async Task<IEnumerable<Government>> GetAllAsync()
        {
            return await _governments.ToListAsync();
        }

        public async Task AddAsync(Government government)
        {
            await _governments.AddAsync(government);
        }

        public void Update(Government government)
        {
            _governments.Update(government);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
