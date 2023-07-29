using AutoMapper;
using cashierAPI.Models;
using cashierAPI.Models.dto;

namespace cashierAPI.util;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<AkunCs, AkunCSDto>();
        CreateMap<AkunCSDto, AkunCs>();
    }
}
