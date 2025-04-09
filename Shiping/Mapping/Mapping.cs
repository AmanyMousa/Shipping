using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Service.DTOS.GovermentDTOS;
using Shipping.Service.DTOS.OrdersDTOS;
using Shipping.Service.DTOS.ProductDTO;
using Shipping.Service.DTOS.ShippingTypeDTO;
using Shipping.Service.DTOS.UsersDTOS;
using Shipping.Service.DTOS.WightPriceDTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddUserDTO, User>();
        CreateMap<User, UsersDTO>();
        CreateMap<OrderDto, Order>();
        CreateMap<ShippingType, ShippingTypesDTO>();

        CreateMap<ShippingTypesDTO, ShippingType>();
        CreateMap<UpdateShippingTypesDTO, ShippingType>();
        CreateMap< ShippingType, UpdateShippingTypesDTO>();
        CreateMap< Government, GovernmentDTO>();
        CreateMap< GovernmentDTO, Government>();
        CreateMap<WeightPrice, WeightPriceDTO>();
        CreateMap< WeightPriceDTO, WeightPrice>();
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto,Order>();
        CreateMap< Product, ProductDTO>();
        CreateMap< ProductDTO, Product>();
        
        CreateMap<ProductUpdateDTO, Product>()
               .ForMember(dest => dest.WeightPrice, opt => opt.Ignore()) // تجاهل العلاقات
               .ForMember(dest => dest.ProdOrders, opt => opt.Ignore())
               .ReverseMap(); // إذا كنت تحتاج Mapping عكسي






    }
}
