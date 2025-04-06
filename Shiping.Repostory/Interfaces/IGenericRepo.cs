using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{
    public interface IGenericRepo<T,t1> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync( t1 id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(t1 id);
    }
    
}
