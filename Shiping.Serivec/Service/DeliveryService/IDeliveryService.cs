using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Service.DTOS.Delivery;

namespace Shipping.Service.Service.DeliveryService
{
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryReadDto>> GetAllAsync();
        Task<DeliveryReadDto?> GetByIdAsync(string id);
        Task<DeliveryReadDto> CreateAsync(DeliveryCreateDto dto);
        Task<bool> UpdateAsync(string id, DeliveryUpdateDto dto);
        Task<bool> DeleteAsync(string id);
    }
}
