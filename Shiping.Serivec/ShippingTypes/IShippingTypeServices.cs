using Shipping.Service.DTOS.ShippingTypeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.ShippingTypes
{
    public interface IShippingTypeServices
    {
        Task<IEnumerable<ShippingTypesDTO>> GetAllShippingTypesAsync();
        Task<ShippingTypesDTO> GetShippingTypeByIdAsync(int id);
        Task AddShippingTypeAsync(ShippingTypesDTO shippingTypeDto);
        Task UpdateShippingTypeAsync(int id, UpdateShippingTypesDTO shippingTypeDto);
        Task DeleteShippingTypeAsync(int id);
    }
}
