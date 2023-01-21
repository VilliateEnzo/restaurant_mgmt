using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Core.Interfaces;

public interface IRestaurantService
{
    Task<IList<Restaurant>> GetRestaurantsAsync();
}