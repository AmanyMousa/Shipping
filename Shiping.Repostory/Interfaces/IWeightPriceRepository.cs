using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{
    public interface IWeightPriceRepository
    {
        Task<WeightPrice> GetByIdAsync(int id);
        Task<IEnumerable<WeightPrice>> GetAllAsync();
        Task AddAsync(WeightPrice weightPrice);

        void Update(WeightPrice weightPrice);
        void Delete(WeightPrice weightPrice);
    }
}
