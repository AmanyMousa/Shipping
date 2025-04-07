using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Service.DTOS.Delivery;

namespace Shipping.Profiles
{
    public class DeliveryProfile : Profile
    {
        public DeliveryProfile()
        {
            CreateMap<Delivery, DeliveryReadDto>();
            CreateMap<DeliveryCreateDto, Delivery>();
            CreateMap<DeliveryUpdateDto, Delivery>();
        }
    }
}
