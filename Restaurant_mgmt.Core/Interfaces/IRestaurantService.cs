using Restaurant_mgmt.Core.DTOs;
using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Core.Interfaces;

public interface IRestaurantService
{
    Task<IList<Restaurant>> GetRestaurantsAsync();

    Task<RestaurantDto> GetRestaurantAsync(Guid id);
    
    Task<Restaurant> CreateRestaurantsAsync(RestaurantDto request);
}