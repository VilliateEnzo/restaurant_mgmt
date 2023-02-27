using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant_mgmt.Core.DTOs;
using Restaurant_mgmt.Core.Exceptions;
using Restaurant_mgmt.Core.Interfaces;

namespace Restaurant_mgmt.Controllers;

[Authorize]
public class RestaurantController : BaseApiController
{
    private readonly IRestaurantService _restaurantService;
    
    public RestaurantController(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetRestaurants()
    {
        return Ok(await _restaurantService.GetRestaurantsAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestaurant(Guid id)
    {
        return Ok(await _restaurantService.GetRestaurantAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurants(RestaurantDto request)
    {
        try
        {
            return Ok(await _restaurantService.CreateRestaurantsAsync(request, User));
        }
        catch (EntityAlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
}