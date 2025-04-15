using AutoMapper;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Entities;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Application.Services
{
    public class RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper) : IRestaurantService
    {
        public async Task<RestaurantDto> GetRestauByIdAsync(int id)
        {
            var restau = await restaurantRepository.GetByIdAsync(id);
            return mapper.Map<RestaurantDto>(restau);
        }
        public async Task<List<RestaurantDto>> GetAllRestauAsync()
        {
            var restaurants = await restaurantRepository.GetAllAsyncr();
            return mapper.Map<List<RestaurantDto>>(restaurants);
        }
        public async Task AddRestauAsync(RestaurantDto restaurantDto)
        {
            var restaurant = mapper.Map<Restaurant>(restaurantDto);
            await restaurantRepository.AddAsyncr(restaurant);
        }
        public async Task UpdateRestauAsync(RestaurantDto restaurantDto)
        {
            var existingRestaurant = await restaurantRepository.GetByIdAsync(restaurantDto.Id);

            if (existingRestaurant == null)
            {
                throw new Exception("Restaurant non trouvé");
            }

            var restaurantEntity = mapper.Map<Restaurant>(restaurantDto);

            existingRestaurant.Nom = restaurantEntity.Nom;
            existingRestaurant.Note = restaurantEntity.Note;
            existingRestaurant.ImageUrl = restaurantEntity.ImageUrl;
            await restaurantRepository.UpdateAsync(existingRestaurant);
        }
        public async Task DeleteRestauAsync(int id)
        {
            await restaurantRepository.DeleteAsync(id);
        }
        public Task<IEnumerable<Restaurant>> GetCuisineAsync(string cuisine) {
            return restaurantRepository.GetByCuisineAsync(cuisine);
        }

    }
}
