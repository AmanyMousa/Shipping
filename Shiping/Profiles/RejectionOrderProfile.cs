using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Service.DTOS.RejectionOrder;

namespace Shipping.Profiles
{
    public class RejectionOrderProfile : Profile
    {
        public RejectionOrderProfile()
        {
            CreateMap<RejectionOrder, GetRejectionOrderDto>();
            CreateMap<CreateRejectionOrderDto, RejectionOrder>();
            CreateMap<UpdateRejectionOrderDto, RejectionOrder>();
        }
    }
}
