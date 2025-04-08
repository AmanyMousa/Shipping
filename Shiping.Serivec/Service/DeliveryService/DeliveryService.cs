using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Delivery;

namespace Shipping.Service.Service.DeliveryService
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public DeliveryService(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeliveryReadDto>> GetAllAsync()
        {
            var deliveries = await _unitOfWork.GetRepository<Delivery, string>().GetAllAsync();
            return _mapper.Map<IEnumerable<DeliveryReadDto>>(deliveries);
        }

        public async Task<DeliveryReadDto?> GetByIdAsync(string id)
        {
            var delivery = await _unitOfWork.GetRepository<Delivery, string>().GetByIdAsync(id);
            return delivery == null ? null : _mapper.Map<DeliveryReadDto>(delivery);
        }

        public async Task<DeliveryReadDto> CreateAsync(DeliveryCreateDto dto)
        {
            var entity = _mapper.Map<Delivery>(dto);
            await _unitOfWork.GetRepository<Delivery, string>().AddAsync(entity);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<DeliveryReadDto>(entity);
        }

        public async Task<bool> UpdateAsync(string id, DeliveryUpdateDto dto)
        {
            var repo = _unitOfWork.GetRepository<Delivery, string>();
            var delivery = await repo.GetByIdAsync(id);
            if (delivery == null) return false;

            _mapper.Map(dto, delivery);
            await repo.UpdateAsync(delivery);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var repo = _unitOfWork.GetRepository<Delivery, string>();
            var delivery = await repo.GetByIdAsync(id);
            if (delivery == null) return false;

            await repo.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }

}
