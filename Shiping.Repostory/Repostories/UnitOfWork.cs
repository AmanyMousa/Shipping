using Shipping.Data;
using Shipping.Repository;
using Shipping.Repostory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Repostories
{
    public class UnitOfWork : IUnitofwork
    {
        private readonly ShippingDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(ShippingDbContext context)
        {
            _context = context;
        }

         IGenericRepo<T> IUnitofwork.GetRepository<T>()
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepo<T>)_repositories[typeof(T)];
            }

            var repository = new GenricRepo<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
