using Microsoft.EntityFrameworkCore;
using Shipping.Data.Entities;
using Shipping.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Repostory.Interfaces;

namespace Shipping.Repostory.Repostories
{

    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _products;
        private readonly ShippingDbContext _context;


        public ProductRepository(ShippingDbContext context)
        {
            _context = context;
            _products = context.Products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _products
                .Include(p => p.WeightPrice)
                .Include(p => p.ProdOrders)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            //return await _products
            //    .Include(p => p.WeightPrice)
            //    .ToListAsync() ?? Enumerable.Empty<Product>();
            return await _context.Products.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetByWeightPriceIdAsync(int weightPriceId)
        {
            return await _products
                .Where(p => p.WeightPriceId == weightPriceId)
                .Include(p => p.WeightPrice)
                .ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _products.Update(product);
        }
        public async Task<int> CountAsync()
        {
            return await _products.CountAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsInStockAsync()
        {
            return await _products
                .Where(p => p.Quantity > 0)
                .Include(p => p.WeightPrice)
                .ToListAsync();
        }
        public void Delete(Product product)
        {
            _products.Remove(product);
        }

        public async Task<bool> Exists(int id)
        {
            return await _products.AnyAsync(p => p.Id == id);
        }

        




    }
}


