
using RestauApp.Domain.Entities;

namespace RestauApp.Domain.Interfaces
{
    public interface ICuisineRepository
    {
        Task<Cuisine> GetCuisineByIdAsync(int id);
        Task<IEnumerable<Cuisine>> GetAllCuisinesAsync();
        Task AddCuisineAsync(Cuisine cuisine);
        Task UpdateCuisineAsync(Cuisine cuisine);
        Task DeleteCuisineAsync(int id);
    }
}
