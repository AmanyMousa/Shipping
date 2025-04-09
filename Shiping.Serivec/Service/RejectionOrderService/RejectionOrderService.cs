using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.RejectionOrder;

namespace Shipping.Service.Service.RejectionOrderService
{
    public class RejectionOrderService : IRejectionOrderService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public RejectionOrderService(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetRejectionOrderDto>> GetAllAsync()
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var data = await repo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetRejectionOrderDto>>(data);
            return result;
        }

        public async Task<GetRejectionOrderDto?> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null || entity.IsDeleted) return null;

            return _mapper.Map<GetRejectionOrderDto>(entity);
        }

        public async Task<bool> CreateAsync(CreateRejectionOrderDto dto)
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var entity = _mapper.Map<RejectionOrder>(dto);
            await repo.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateRejectionOrderDto dto)
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null || entity.IsDeleted) return false;

            _mapper.Map(dto, entity);
            await repo.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<RejectionOrder, int>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null || entity.IsDeleted) return false;

            entity.IsDeleted = true;
            await repo.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }


}
