using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Service.DTOS.Branch;

namespace Shipping.Profiles
{
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchReadDto>();
            CreateMap<BranchCreateDto, Branch>();
            CreateMap<BranchUpdateDto, Branch>();
        }
    }
}
