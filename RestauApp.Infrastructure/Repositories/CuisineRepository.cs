using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestauApp.Domain.Entities;
using RestauApp.Domain.Interfaces;
using RestauApp.Infrastructure.Data;

namespace RestauApp.Infrastructure.Repositories
{
    public class CuisineRepository(MyDbContext myDbContext, ILogger<CuisineRepository> logger) : ICuisineRepository
    {
        public async Task<Cuisine> GetCuisineByIdAsync(int id)
        {
            logger.LogInformation("récupération de la cuisine avec id : {id}", id);
            return await myDbContext.Cuisines.FindAsync(id)
                ?? throw new KeyNotFoundException($"la cuisine avec id : {id} est introuvable!!");
        }

        public async Task<IEnumerable<Cuisine>> GetAllCuisinesAsync()
        {
            logger.LogInformation("récupération de toutes les cuisines");
            return await myDbContext.Cuisines.ToListAsync();
        }

        public async Task AddCuisineAsync(Cuisine cuisine)
        {
            logger.LogInformation("ajout d'une nouvelle cuisine : {nom}", cuisine.Nom.ToLower());
            await myDbContext.Cuisines.AddAsync(cuisine);
            await myDbContext.SaveChangesAsync();
        }

        public async Task UpdateCuisineAsync(Cuisine cuisine)
        {
            logger.LogInformation("mise à jour de la cuisine : {id}", cuisine.Id);
            myDbContext.Cuisines.Update(cuisine);
            await myDbContext.SaveChangesAsync();
        }

        public async Task DeleteCuisineAsync(int id)
        {
            logger.LogInformation("suppression de la cuisine : {id}", id);
            var cuisine = await GetCuisineByIdAsync(id);
            if (cuisine != null)
            {
                myDbContext.Cuisines.Remove(cuisine);
                await myDbContext.SaveChangesAsync();
            }
        }
    }
}