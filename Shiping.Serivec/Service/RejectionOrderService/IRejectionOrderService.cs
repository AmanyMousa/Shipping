using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Service.DTOS.RejectionOrder;

namespace Shipping.Service.Service.RejectionOrderService
{
    public interface IRejectionOrderService
    {
        Task<IEnumerable<GetRejectionOrderDto>> GetAllAsync();
        Task<GetRejectionOrderDto?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateRejectionOrderDto dto);
        Task<bool> UpdateAsync(int id, UpdateRejectionOrderDto dto);
        Task<bool> SoftDeleteAsync(int id);
    }
}
