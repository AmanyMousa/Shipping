using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{
    public interface IGovernmentRepository
    {
        Task<Government> GetByIdAsync(int id);
        Task<IEnumerable<Government>> GetAllAsync();
        Task AddAsync(Government government);
        void Update(Government government);
        Task SaveChangesAsync();
        Task<IEnumerable<Government>> GetGovernmentsByStatusAsync(string status);
    }
}
