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
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(ShippingDbContext context)
        {
            _context = context;
            _repositories = new();
        }

         IGenericRepo<T,t1> IUnitofwork.GetRepository<T,t1>()
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IGenericRepo<T,t1>)_repositories[typeof(T)];
            }

            var repository = new GenricRepo<T,t1>(_context);
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
