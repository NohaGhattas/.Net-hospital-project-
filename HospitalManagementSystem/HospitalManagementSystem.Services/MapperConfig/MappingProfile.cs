
using AutoMapper;
using HospitalManagementSystem.Models.Dtos;
using HospitalManagementSystem.Models.Users;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UsersDto>();
       
    }
}


