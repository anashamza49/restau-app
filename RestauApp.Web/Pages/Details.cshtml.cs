using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Entities;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Web.Pages
{
    public class DetailsModel(IRestaurantRepository restaurantRepository) : PageModel
    {
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Restaurant = await restaurantRepository.GetByIdAsync(id);

            if (Restaurant == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
