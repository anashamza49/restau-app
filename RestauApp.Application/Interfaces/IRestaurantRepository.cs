
using RestauApp.Domain.Entities;

namespace RestauApp.Domain.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetByIdAsync(int id);
        Task<IEnumerable<Restaurant>> GetAllAsync();
        Task AddAsync(Restaurant restaurant);
        Task UpdateAsync(Restaurant restaurant);
        Task DeleteAsync(int id);
        Task<IEnumerable<Restaurant>> GetByCuisineAsync(string cuisine);
    }
}
