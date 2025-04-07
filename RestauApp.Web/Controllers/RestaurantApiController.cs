using Microsoft.AspNetCore.Mvc;
using RestauApp.Application.DTOs;
using RestauApp.Domain.Interfaces;

namespace RestauApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantApiController(IRestaurantService restaurantService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantService.GetAllRestauAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var restaurant = await restaurantService.GetRestauByIdAsync(id);
            if (restaurant == null) return NotFound();
            return Ok(restaurant);
        }

        [HttpGet("cuisine/{cuisine}")]
        public async Task<IActionResult> GetByCuisine(string cuisine)
        {
            var restaurants = await restaurantService.GetCuisineAsync(cuisine);
            return Ok(restaurants);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RestaurantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await restaurantService.AddRestauAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RestaurantDto dto)
        {
            if (id != dto.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await restaurantService.UpdateRestauAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await restaurantService.DeleteRestauAsync(id);
            return NoContent();
        }
    }
}
