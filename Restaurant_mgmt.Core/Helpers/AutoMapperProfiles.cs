using AutoMapper;
using Restaurant_mgmt.Core.DTOs;
using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Core.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<RegisterDto, AppUser>();
        CreateMap<RestaurantDto, Restaurant>();
        CreateMap<Restaurant, RestaurantDto>();
    }
}