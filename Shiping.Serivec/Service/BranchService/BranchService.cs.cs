using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Service.DTOS.Branch;

namespace Shipping.Service.Service.BranchService
{
    public class BranchService : IBranchService
    {
        private readonly IUnitofwork _unitOfWork;
        private readonly IMapper _mapper;

        public BranchService(IUnitofwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BranchReadDto>> GetAllAsync()
        {
            var branches = await _unitOfWork.GetRepository<Branch, int>().GetAllAsync();
            return _mapper.Map<IEnumerable<BranchReadDto>>(branches.Where(b => !b.IsDeleted));
        }

        public async Task<BranchReadDto?> GetByIdAsync(int id)
        {
            var branch = await _unitOfWork.GetRepository<Branch, int>().GetByIdAsync(id);
            if (branch == null || branch.IsDeleted) return null;
            return _mapper.Map<BranchReadDto>(branch);
        }

        public async Task<BranchReadDto> CreateAsync(BranchCreateDto dto)
        {
            var branch = _mapper.Map<Branch>(dto);
            branch.IsDeleted = false;

            await _unitOfWork.GetRepository<Branch, int>().AddAsync(branch);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<BranchReadDto>(branch);
        }

        public async Task<bool> UpdateAsync(int id, BranchUpdateDto dto)
        {
            if (id != dto.Bid) return false;

            var repo = _unitOfWork.GetRepository<Branch, int>();
            var existingBranch = await repo.GetByIdAsync(id);

            if (existingBranch == null || existingBranch.IsDeleted) return false;

            _mapper.Map(dto, existingBranch);
            await repo.UpdateAsync(existingBranch);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Branch, int>();
            var branch = await repo.GetByIdAsync(id);

            if (branch == null || branch.IsDeleted) return false;

            branch.IsDeleted = true;
            await repo.UpdateAsync(branch);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }

}