using AutoMapper;
using Shipping.Data.Entities;
using Shipping.Serivec.Users.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserpassDTO, User>();
        CreateMap<User, UsersDTO>();
      
       

    }
}
