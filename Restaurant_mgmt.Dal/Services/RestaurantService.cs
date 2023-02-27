using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant_mgmt.Core.DTOs;
using Restaurant_mgmt.Core.Entities;
using Restaurant_mgmt.Core.Errors;
using Restaurant_mgmt.Core.Exceptions;
using Restaurant_mgmt.Core.Interfaces;
using Restaurant_mgmt.Dal.Data;
using Restaurant_mgmt.Dal.Extensions;

namespace Restaurant_mgmt.Dal.Services;

public class RestaurantService : IRestaurantService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;

    public RestaurantService(DataContext dataContext, IMapper mapper, UserManager<AppUser> userManager)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _userManager = userManager;
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

    public async Task<Restaurant> CreateRestaurantsAsync(RestaurantDto request, ClaimsPrincipal user)
    {
        if (await RestaurantByNameAndUbicationExistAsync(request)) throw new EntityAlreadyExistsException("Restaurant");

        AppUser appUser = await _userManager.FindUserByClaimsPrincipleEmail(user);

        Restaurant restaurantToCreate = _mapper.Map<Restaurant>(request);

        restaurantToCreate.CreatedById = appUser.Id;
        restaurantToCreate.CreatedAt = DateTime.UtcNow;

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