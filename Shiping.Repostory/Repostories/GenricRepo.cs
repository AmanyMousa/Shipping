using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Repostory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Repostories
{
    public class GenricRepo<T,t1> : IGenericRepo<T,t1> where T : class
    {
        private readonly ShippingDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenricRepo(ShippingDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
          
        }

        public async Task DeleteAsync(t1 id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
              
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(t1 id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
           
        }
    }
   
}
