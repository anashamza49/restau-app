using AutoMapper;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Entities;

namespace RestauApp.Application.Profiles
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<RestaurantDto, RestaurantDto>();
            CreateMap<RestaurantDto, Restaurant>()
                .ForMember(c => c.CuisineId, opt => opt.Ignore())
                .ForMember(c => c.Cuisine, opt => opt.Ignore());
        }
    }
}
