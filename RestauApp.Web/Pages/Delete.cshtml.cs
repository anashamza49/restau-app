using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestauApp.Domain.Entities;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Web.Pages
{
    public class DeleteModel(IRestaurantRepository restaurantRepository) : PageModel
    {
        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Restaurant = await restaurantRepository.GetByIdAsync(id);
            if (Restaurant == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await restaurantRepository.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
