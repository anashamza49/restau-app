using Microsoft.AspNetCore.Mvc.RazorPages;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Interfaces;

public class IndexModel : PageModel
{
    private readonly IRestaurantService _restaurantService;

    public IndexModel(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public List<RestaurantDto> Restaurants { get; set; }

    public async Task OnGetAsync()
    {
        Restaurants = await _restaurantService.GetAllRestauAsync();
    }
}
