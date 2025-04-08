using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Serivec.DTOS;
using Shipping.Service.DTOS.CityDTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddUserDTO, User>().ReverseMap();
        CreateMap<User, UsersDTO>();
        CreateMap<City, CityDto>().ReverseMap();


    }
}
