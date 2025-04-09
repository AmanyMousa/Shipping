using Shipping.Data.Entities;
using Shipping.Service.DTOS.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.Products
{
    public interface IProductServices
    {
        Task<ProductDTO> GetByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetAllAsync();
        Task AddAsync(ProductUpdateDTO productDto);
        Task<bool> UpdateAsync(int id, ProductUpdateDTO productDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ProductDTO>> GetByWeightPriceIdAsync(int weightPriceId);
        Task<int> GetProductCountAsync();
        Task<IEnumerable<ProductDTO>> GetProductsInStockAsync();

    }
}
