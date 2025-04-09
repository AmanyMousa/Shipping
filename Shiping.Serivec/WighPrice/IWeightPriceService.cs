using Shipping.Service.DTOS.WightPriceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.WighPrice
{
    public interface IWeightPriceService
    {
        Task<WeightPriceDTO> GetByIdAsync(int id);
        Task<IEnumerable<WeightPriceDTO>> GetAllAsync();
        Task AddAsync(WeightPriceDTO weightPriceDto);
        //Task<IEnumerable<WeightPriceDTO>> SearchAsync(decimal? minPrice, decimal? maxPrice);
        Task<bool> UpdateAsync(int id, WeightPriceDTO weightPriceDto);
        Task<bool> DeleteAsync(int id);
    }
}
