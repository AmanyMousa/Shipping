using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Marchant;

namespace Shipping.Service.Service.MarchantService
{
    public class MarchantService : IMarchantService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public MarchantService(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMarchantDto>> GetAllAsync()
        {
            var marchants = await _unitOfWork.GetRepository<Marchant, string>().GetAllAsync();
            return _mapper.Map<IEnumerable<GetMarchantDto>>(marchants);
        }

        public async Task<GetMarchantDto?> GetByIdAsync(string id)
        {
            var marchant = await _unitOfWork.GetRepository<Marchant, string>().GetByIdAsync(id);
            return marchant == null ? null : _mapper.Map<GetMarchantDto>(marchant);
        }

        public async Task CreateAsync(CreateMarchantDto dto)
        {
            var entity = _mapper.Map<Marchant>(dto);
            await _unitOfWork.GetRepository<Marchant, string>().AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> UpdateAsync(string id, UpdateMarchantDto dto)
        {
            var repo = _unitOfWork.GetRepository<Marchant, string>();
            var marchant = await repo.GetByIdAsync(id);
            if (marchant == null) return false;

            _mapper.Map(dto, marchant);
            await repo.UpdateAsync(marchant);
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var repo = _unitOfWork.GetRepository<Marchant, string>();
            var marchant = await repo.GetByIdAsync(id);
            if (marchant == null) return false;

            await repo.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }

}
