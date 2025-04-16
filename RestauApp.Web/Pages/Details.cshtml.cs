using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Web.Pages
{
    public class DetailsModel(IRestaurantService restaurantService) : PageModel
    {
        public RestaurantDto Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Restaurant = await restaurantService.GetRestauByIdAsync(2);

            if (Restaurant == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
