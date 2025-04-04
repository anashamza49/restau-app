
using RestauApp.Application.DTOs;

namespace RestauApp.Domain.Interfaces
{
    public interface ICuisineService
    {
        Task<List<CuisineDto>> GetAllAsync();
        Task<CuisineDto> GetByIdAsync(int id);
        Task AddAsync(CuisineDto cuisineDto);
        Task UpdateAsync(CuisineDto cuisineDto);
        Task DeleteAsync(int id);
    }
}
