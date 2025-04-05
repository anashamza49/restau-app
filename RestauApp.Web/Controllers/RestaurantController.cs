using Microsoft.AspNetCore.Mvc;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Web.Controllers
{
    public class RestaurantController(IRestaurantService restaurantService) : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var restaurants = await restaurantService.GetAllRestauAsync();
            return View(restaurants);
        }

        [HttpGet("Cuisine/{cuisine}")]
        public async Task<IActionResult> GetByCuisine(string cuisine)
        {
            var restaurants = await restaurantService.GetCuisineAsync(cuisine);
            return View("Index", restaurants);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await restaurantService.GetRestauByIdAsync(id);
            if (restaurant == null) return NotFound();
            return View(restaurant);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(RestaurantDto restaurantDto, IFormFile? imageFile)
        {
            if (imageFile == null || imageFile.Length == 0)
            {
                ViewData["ImageError"] = "L'image est obligatoire !";
                return View(restaurantDto);
            }

            if (ModelState.IsValid)
            {
                restaurantDto.ImageUrl = await UploadImage(imageFile);
                await restaurantService.AddRestauAsync(restaurantDto);
                Console.WriteLine($"Ajout restaurant : {restaurantDto.Nom}, {restaurantDto.Note}, {restaurantDto.ImageUrl}");
                return RedirectToAction(nameof(Index));
            }

            return View(restaurantDto);
        }


        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var restaurant = await restaurantService.GetRestauByIdAsync(id);
            if (restaurant == null) return NotFound();
            return View(restaurant);
        }

        [HttpPost("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, RestaurantDto restaurantDto, IFormFile imageFile)
        {
            if (id != restaurantDto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    restaurantDto.ImageUrl = await UploadImage(imageFile);
                }

                await restaurantService.UpdateRestauAsync(restaurantDto);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantDto);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await restaurantService.DeleteRestauAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> UploadImage(IFormFile file)
        {
            var uploadsFolder = Path.Combine("wwwroot", "images", "restaurants");
            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/images/restaurants/{uniqueFileName}";
        }
    }
}
