using AutoMapper;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Entities;

namespace RestauApp.Application.Profiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantDto, Restaurant>()
                .ForMember(dest => dest.Cuisine, opt => opt.Ignore());

        }
    }
}
