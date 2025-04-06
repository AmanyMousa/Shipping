using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Serivec.DTOS;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddUserDTO, User>();
        CreateMap<User, UsersDTO>();
      
       

    }
}
