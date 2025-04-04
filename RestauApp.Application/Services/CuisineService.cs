using AutoMapper;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Entities;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Application.Services
{
    public class CuisineService(ICuisineRepository cuisineRepository, IMapper mapper) : ICuisineService
    {

        public async Task<List<CuisineDto>> GetAllAsync()
        {
            var cuisines = await cuisineRepository.GetAllCuisinesAsync();
            return mapper.Map<List<CuisineDto>>(cuisines);
        }

        public async Task<CuisineDto> GetByIdAsync(int id)
        {
            var cuisine = await cuisineRepository.GetCuisineByIdAsync(id);
            return mapper.Map<CuisineDto>(cuisine);
        }

        public async Task AddAsync(CuisineDto cuisineDto)
        {
            var cuisine = mapper.Map<Cuisine>(cuisineDto);
            await cuisineRepository.AddCuisineAsync(cuisine);
        }

        public async Task UpdateAsync(CuisineDto cuisineDto)
        {
            var cuisine = mapper.Map<Cuisine>(cuisineDto);
            await cuisineRepository.UpdateCuisineAsync(cuisine);
        }

        public async Task DeleteAsync(int id)
        {
            await cuisineRepository.DeleteCuisineAsync(id);
        }
    }
}
