using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.WightPriceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.WighPrice
{
    public class WeightPriceService : IWeightPriceService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public WeightPriceService(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(WeightPriceDTO weightPriceDto)
        {
            var weightPrice = _mapper.Map<WeightPrice>(weightPriceDto);
            await _unitOfWork.WeightPrices.AddAsync(weightPrice);
            await _unitOfWork.CompleteAsync();
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var weightPrice = await _unitOfWork.WeightPrices.GetByIdAsync(id);
                if (weightPrice == null)
                    return false;

                // Check if any products are using this weight price
                var productsUsingWeightPrice = await _unitOfWork.Products.GetByWeightPriceIdAsync(id); //error
                if (productsUsingWeightPrice.Any())
                {
                    throw new InvalidOperationException("Cannot delete weight price - it's being used by products");
                }

                _unitOfWork.WeightPrices.Delete(weightPrice);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the weight price: {ex.Message}", ex);
            }
        }        

      
        public async Task<IEnumerable<WeightPriceDTO>> GetAllAsync()
        {
            try
            {
                var weightPrices = await _unitOfWork.WeightPrices.GetAllAsync();
                return _mapper.Map<IEnumerable<WeightPriceDTO>>(weightPrices);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving weight prices: {ex.Message}", ex);
            }
        }        

        public async Task<WeightPriceDTO> GetByIdAsync(int id)
        
            {
                try
                {
                    var weightPrice = await _unitOfWork.WeightPrices.GetByIdAsync(id);
                    if (weightPrice == null)
                    {
                        throw new KeyNotFoundException($"Weight price with ID {id} not found");
                    }
                    return _mapper.Map<WeightPriceDTO>(weightPrice);
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
        public async Task<bool> UpdateAsync(int id, WeightPriceDTO weightPriceDto)
        {
            try
            {
                if (id != weightPriceDto.Id)
                    return false;

                var existingWeightPrice = await _unitOfWork.WeightPrices.GetByIdAsync(id);
                if (existingWeightPrice == null)
                    return false;

                _mapper.Map(weightPriceDto, existingWeightPrice);
                _unitOfWork.WeightPrices.Update(existingWeightPrice);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
