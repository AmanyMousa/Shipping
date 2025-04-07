using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Service.DTOS.Marchant;

namespace Shipping.Profiles
{
    public class MarchantProfile : Profile
    {
        public MarchantProfile()
        {
            CreateMap<Marchant, GetMarchantDto>();
            CreateMap<CreateMarchantDto, Marchant>();
            CreateMap<UpdateMarchantDto, Marchant>();
        }
    }
}
