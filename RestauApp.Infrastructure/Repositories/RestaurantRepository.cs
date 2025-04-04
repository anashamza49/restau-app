using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestauApp.Domain.Entities;
using RestauApp.Domain.Interfaces;
using RestauApp.Infrastructure.Data;

namespace RestauApp.Infrastructure.Repositories
{
    public class RestaurantRepository(MyDbContext myDbContext, ILogger<RestaurantRepository> logger) : IRestaurantRepository
    {
        public async Task<Restaurant> GetByIdAsync(int id)
        {
            logger.LogInformation("récupération du restaurant avec id : {id}", id);
            return await myDbContext.Restaurants.FindAsync(id)
                    ?? throw new KeyNotFoundException($"le restaurant avec id : {id} est introuvable !");
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            logger.LogInformation("récupération de tous les restaurants");
            return await myDbContext.Restaurants.ToListAsync();
        }

        public async Task AddAsync(Restaurant restaurant)
        {
            logger.LogInformation("ajout d'un nouveau restaurant : {nom}", restaurant.Nom.ToLower());
            await myDbContext.Restaurants.AddAsync(restaurant);
            await myDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            logger.LogInformation("mise à jour du restaurant : {id}", restaurant.Id);
            myDbContext.Restaurants.Update(restaurant);
            await myDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            logger.LogInformation("suppression du restaurant : {id}", id);
            var restaurant = await GetByIdAsync(id);
            if (restaurant != null)
            {
                myDbContext.Restaurants.Remove(restaurant);
                await myDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Restaurant>> GetByCuisineAsync(string cuisine)
        {
            logger.LogInformation("récupération des restaurants par cuisine : {cuisine}", cuisine.ToLower());
            return await myDbContext.Restaurants.Where(r => r.Cuisine.Nom == cuisine).ToListAsync();
        }
    }
}