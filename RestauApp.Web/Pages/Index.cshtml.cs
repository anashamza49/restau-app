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

    public IList<RestaurantDto> Restaurants { get; set; } = new List<RestaurantDto>();

    public async Task OnGetAsync()
    {
        Restaurants = await _restaurantService.GetAllRestauAsync();
    }
}
