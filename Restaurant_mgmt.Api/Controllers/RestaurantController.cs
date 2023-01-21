using Microsoft.AspNetCore.Mvc;
using Restaurant_mgmt.Core.Interfaces;

namespace Restaurant_mgmt.Controllers;

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
}