
using RestauApp.Application.DTOs;
using RestauApp.Domain.Entities;

namespace RestauApp.Domain.Interfaces
{
    public interface IRestaurantService
    {
        Task<RestaurantDto> GetRestauByIdAsync(int id);
        Task<List<RestaurantDto>> GetAllRestauAsync();
        Task AddRestauAsync(RestaurantDto restaurantDto);
        Task UpdateRestauAsync(RestaurantDto newRestaurantDto);
        Task DeleteRestauAsync(int id);
        Task<IEnumerable<Restaurant>> GetCuisineAsync(string cuisine);

    }
}
