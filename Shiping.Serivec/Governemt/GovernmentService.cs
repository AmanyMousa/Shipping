using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Repostory.Repostories;
using Shipping.Service.DTOS.GovermentDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.Governemt
{
    public class GovernmentService : IGovernmentService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public GovernmentService(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddGovernmentAsync(GovernmentDTO governmentDto)
        {
            var government = _mapper.Map<Government>(governmentDto);
            await _unitOfWork.Governments.AddAsync(government);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<GovernmentDTO>> GetAllGovernmentsAsync()
        {
            var governments = await _unitOfWork.Governments.GetAllAsync();
            return _mapper.Map<IEnumerable<GovernmentDTO>>(governments);
        }

        public async Task<GovernmentDTO> GetGovernmentByIdAsync(int id)
        {
            var government = await _unitOfWork.Governments.GetByIdAsync(id);
            return _mapper.Map<GovernmentDTO>(government);
        }

        public async Task<IEnumerable<GovernmentDTO>> GetGovernmentsByStatusAsync(string status)
        {
            var governments = await _unitOfWork.Governments.GetGovernmentsByStatusAsync(status);
            return _mapper.Map<IEnumerable<GovernmentDTO>>(governments);
        }

        public async Task<bool> UpdateGovernmentAsync(int id, GovernmentDTO governmentDto)
        {
            var government = await _unitOfWork.Governments.GetByIdAsync(id);
            if (government == null) return false;

            _mapper.Map(governmentDto, government);
            _unitOfWork.Governments.Update(government);
            await _unitOfWork.CompleteAsync();
            return true;
        }

    }
}

