using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IRestaurantService _restaurantService;

        public DetailsModel(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        public RestaurantDto Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Restaurant = await _restaurantService.GetRestauByIdAsync(id);

            if (Restaurant == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
