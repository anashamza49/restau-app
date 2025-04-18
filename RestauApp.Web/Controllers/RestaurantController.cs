﻿using Microsoft.AspNetCore.Mvc;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Web.Controllers
{
    [Route("Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public async Task<IActionResult> Index()
        {
            var restaurants = await _restaurantService.GetAllRestauAsync();
            return View(restaurants);
        }

        [HttpGet("Cuisine/{cuisine}")]
        public async Task<IActionResult> GetByCuisine(string cuisine)
        {
            var restaurants = await _restaurantService.GetCuisineAsync(cuisine);
            return View("Index", restaurants);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var restaurant = await _restaurantService.GetRestauByIdAsync(id);
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
                return View(restaurantDto);
            }

            if (ModelState.IsValid)
            {
                restaurantDto.ImageUrl = await UploadImage(imageFile);
                await _restaurantService.AddRestauAsync(restaurantDto);
                return RedirectToAction(nameof(Index));
            }

            return View(restaurantDto);
        }

        [HttpGet("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var restaurant = await _restaurantService.GetRestauByIdAsync(id);
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

                await _restaurantService.UpdateRestauAsync(restaurantDto);
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantDto);
        }

        [HttpGet("Delete/{id:int}")]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var restaurant = await _restaurantService.GetRestauByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _restaurantService.DeleteRestauAsync(id);
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
