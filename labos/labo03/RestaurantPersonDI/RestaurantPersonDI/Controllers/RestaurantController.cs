using Microsoft.AspNetCore.Mvc;
using RestaurantPersonDI.Models;
using RestaurantPersonDI.Services;

namespace RestaurantPersonDI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantController : ControllerBase
{
    private readonly RestaurantService _restaurantService;

    public RestaurantController()
    {
        _restaurantService = new RestaurantService();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
    {
        var post = await _restaurantService.GetRestaurantById(id);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpPost]
    public async Task<ActionResult<Restaurant>> CreatePost(Restaurant restaurant)
    {
        await _restaurantService.CreateRestaurant(restaurant);
        return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
    }

    [HttpGet]
    public async Task<ActionResult<List<Restaurant>>> GetPosts()
    {
        var posts = await _restaurantService.GetAllRestaurants();
        return Ok(posts);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(int id, Restaurant restaurant)
    {
        if (id != restaurant.Id)
        {
            return BadRequest();
        }

        var updatedPost = await _restaurantService.UpdateRestaurant(id, restaurant);
        if (updatedPost == null)
        {
            return NotFound();
        }

        return Ok(restaurant);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost(int id)
    {
        var post = await _restaurantService.GetRestaurantById(id);
        if (post == null)
        {
            return NotFound();
        }

        await _restaurantService.DeleteRestaurant(id);
        return NoContent();
    }
}

