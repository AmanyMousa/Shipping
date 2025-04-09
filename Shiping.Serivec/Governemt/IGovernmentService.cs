using Shipping.Service.DTOS.GovermentDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.Governemt
{
    public interface IGovernmentService
    {
        Task<IEnumerable<GovernmentDTO>> GetAllGovernmentsAsync();
        Task<GovernmentDTO> GetGovernmentByIdAsync(int id);
        Task AddGovernmentAsync(GovernmentDTO governmentDto);
        Task<bool> UpdateGovernmentAsync(int id, GovernmentDTO governmentDto);
        Task<IEnumerable<GovernmentDTO>> GetGovernmentsByStatusAsync(string status);
    }
}
