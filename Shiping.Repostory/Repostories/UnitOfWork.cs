using Shipping.Data;
using Shipping.Data.Entities;
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
        private readonly IProductRepository products;
        private readonly Dictionary<Type, object> _repositories;
        public IOrderRepository Orders { get; }
        public IShippingTypeRepository ShippingTypes { get; }
        public IGovernmentRepository Governments { get; }
        public IWeightPriceRepository WeightPrices { get; }

        public IProductRepository Products { get; }

        public UnitOfWork(ShippingDbContext context, IOrderRepository orderRepository, IWeightPriceRepository weightPriceRepository,
            IProductRepository _Products, IShippingTypeRepository ShippingTypes, IGovernmentRepository governmentRepository)
        {
            _context = context;
            _repositories = new();
            Orders = orderRepository;
            this.ShippingTypes = ShippingTypes;
            WeightPrices = weightPriceRepository;
            Products = _Products ?? throw new ArgumentNullException(nameof(_Products));
            Governments = governmentRepository; 
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
