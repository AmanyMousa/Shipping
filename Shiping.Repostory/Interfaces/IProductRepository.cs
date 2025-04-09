using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        void Update(Product product);
        void Delete(Product product);
        Task<bool> Exists(int id);
        Task<IEnumerable<Product>> GetByWeightPriceIdAsync(int weightPriceId);
        Task<int> CountAsync();
        Task<IEnumerable<Product>> GetProductsInStockAsync();

    }
}
