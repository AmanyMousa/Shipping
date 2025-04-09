using Microsoft.EntityFrameworkCore;
using Shipping.Data.Entities;
using Shipping.Data;
using Shipping.Repostory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Repostories
{
     public class WeightPriceRepository : IWeightPriceRepository
    {
        private readonly DbSet<WeightPrice> _weightPrices;

        public WeightPriceRepository(ShippingDbContext context)
        {
            _weightPrices = context.WeightPrices;
        }

        public async Task<WeightPrice> GetByIdAsync(int id)
            => await _weightPrices.FindAsync(id);

        public async Task<IEnumerable<WeightPrice>> GetAllAsync()
            => await _weightPrices.ToListAsync();

        public async Task AddAsync(WeightPrice weightPrice)
            => await _weightPrices.AddAsync(weightPrice);

        public void Update(WeightPrice weightPrice)
            => _weightPrices.Update(weightPrice);

        public void Delete(WeightPrice weightPrice)
            => _weightPrices.Remove(weightPrice);
    }
}
