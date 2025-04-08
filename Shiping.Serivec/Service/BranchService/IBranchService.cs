using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.Service.BranchService
{
    using Shipping.Service.DTOS.Branch;

    public interface IBranchService
    {
        Task<IEnumerable<BranchReadDto>> GetAllAsync();
        Task<BranchReadDto?> GetByIdAsync(int id);
        Task<BranchReadDto> CreateAsync(BranchCreateDto dto);
        Task<bool> UpdateAsync(int id, BranchUpdateDto dto);
        Task<bool> SoftDeleteAsync(int id);
    }
}
