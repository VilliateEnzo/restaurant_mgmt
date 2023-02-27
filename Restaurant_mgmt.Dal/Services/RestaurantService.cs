using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant_mgmt.Core.DTOs;
using Restaurant_mgmt.Core.Entities;
using Restaurant_mgmt.Core.Errors;
using Restaurant_mgmt.Core.Exceptions;
using Restaurant_mgmt.Core.Interfaces;
using Restaurant_mgmt.Dal.Data;

namespace Restaurant_mgmt.Dal.Services;

public class RestaurantService : IRestaurantService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public RestaurantService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    
    public async Task<IList<Restaurant?>> GetRestaurantsAsync()
    {
        return await _dataContext.Restaurants.ToListAsync();
    }

    public async Task<RestaurantDto> GetRestaurantAsync(Guid id)
    {
        Restaurant restaurant = await _dataContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<RestaurantDto>(restaurant);
    }

    public async Task<Restaurant> CreateRestaurantsAsync(RestaurantDto request)
    {
        if (await RestaurantByNameAndUbicationExistAsync(request)) throw new EntityAlreadyExistsException("Restaurant");
        
        Restaurant restaurantToCreate = _mapper.Map<Restaurant>(request);

        await _dataContext.Restaurants.AddAsync(restaurantToCreate);
        await _dataContext.SaveChangesAsync();

        return restaurantToCreate;
    }

    public async Task<bool> RestaurantByNameAndUbicationExistAsync(RestaurantDto restaurant)
    {
        return await _dataContext.Restaurants.AnyAsync(x =>
            x.Name == restaurant.Name && x.Ubication == restaurant.Ubication);
    }
}