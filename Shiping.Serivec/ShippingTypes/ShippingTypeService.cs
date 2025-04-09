using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Repostory.Repostories;
using Shipping.Service.DTOS;
using Shipping.Service.DTOS.ShippingTypeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.ShippingTypes
{
    public class ShippingTypeService : IShippingTypeServices
    {
        private readonly IShippingTypeRepository _repository;

        private readonly IMapper _mapper;
        private readonly IUnitofwork _unitOfWork;

        public ShippingTypeService(IMapper mapper, IUnitofwork _unitOfWork, IShippingTypeRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
            this._unitOfWork = _unitOfWork;
        }
        public async Task<IEnumerable<ShippingTypesDTO>> GetAllShippingTypesAsync()
        {
            var shippingTypes = await  _repository.GetAllShippingTypesAsync();
            return _mapper.Map<IEnumerable<ShippingTypesDTO>>(shippingTypes);
        }
        public async Task<ShippingTypesDTO> GetShippingTypeByIdAsync(int id)
        {
            var shippingType = await _repository.GetShippingTypeByIdAsync(id);
            return _mapper.Map<ShippingTypesDTO>(shippingType);
        }

        public async Task DeleteShippingTypeAsync(int id) {
            await _repository.DeleteShippingTypeAsync(id);
            await _unitOfWork.CompleteAsync();
        }
     
        public async Task AddShippingTypeAsync(ShippingTypesDTO shippingTypeDto)
        {
            var shippingType = _mapper.Map<ShippingType>(shippingTypeDto);
            shippingType.IsDeleted = false;
            shippingType.SetShippingDetails();
            await _repository.AddShippingTypeAsync(shippingType);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateShippingTypeAsync(int id, UpdateShippingTypesDTO shippingTypeDto)
        {
            var shippingType = await _repository.GetShippingTypeByIdAsync(id);
            if (shippingType != null)
            {
                _mapper.Map(shippingTypeDto, shippingType);
                shippingType.SetShippingDetails();
                await _repository.UpdateShippingTypeAsync(id, shippingType);
                await _unitOfWork.CompleteAsync();
            }
        }



    }
}

