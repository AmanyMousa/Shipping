using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Service.DTOS.Marchant;

namespace Shipping.Service.Service.MarchantService
{
    public interface IMarchantService
    {
        Task<IEnumerable<GetMarchantDto>> GetAllAsync();
        Task<GetMarchantDto?> GetByIdAsync(string id);
        Task CreateAsync(CreateMarchantDto dto);
        Task<bool> UpdateAsync(string id, UpdateMarchantDto dto);
        Task<bool> DeleteAsync(string id);
    }
}
