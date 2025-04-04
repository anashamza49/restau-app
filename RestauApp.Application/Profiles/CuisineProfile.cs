
using AutoMapper;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Entities;


namespace RestauApp.Application.Profiles
{
    public class CuisineProfile : Profile
    {
        public CuisineProfile()
        {
            CreateMap<Cuisine, CuisineDto>();
            CreateMap<CuisineDto, Cuisine>();
        }
    }
}
