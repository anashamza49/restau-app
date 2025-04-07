using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Web.Pages
{
    public class CreateModel(IRestaurantService restaurantService, IWebHostEnvironment env) : PageModel
    {
        [BindProperty]
        public RestaurantDto Restaurant { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model invalide");
                return Page();
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var folderPath = Path.Combine(env.WebRootPath, "images", "restaurants");
                Directory.CreateDirectory(folderPath);
                var fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                Restaurant.ImageUrl = $"/images/restaurants/{fileName}";
            }

            await restaurantService.AddRestauAsync(Restaurant);
            return RedirectToPage("Index");
        }
    }
}
