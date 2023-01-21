using Microsoft.EntityFrameworkCore;
using Restaurant_mgmt.Core.Entities;
using Restaurant_mgmt.Core.Interfaces;
using Restaurant_mgmt.Dal.Data;

namespace Restaurant_mgmt.Dal.Services;

public class RestaurantService : IRestaurantService
{
    private readonly DataContext _dataContext;
    
    public RestaurantService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<IList<Restaurant>> GetRestaurantsAsync()
    {
        return await _dataContext.Restaurants.ToListAsync();
    }
}