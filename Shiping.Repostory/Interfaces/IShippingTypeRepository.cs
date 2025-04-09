using Shipping.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{
    public interface IShippingTypeRepository
    {
        Task<IEnumerable<ShippingType>> GetAllShippingTypesAsync();
        Task<ShippingType> GetShippingTypeByIdAsync(int id);
        Task AddShippingTypeAsync(ShippingType shippingType);
        Task UpdateShippingTypeAsync(int id, ShippingType shippingType);
        Task DeleteShippingTypeAsync(int id);
    }
}
