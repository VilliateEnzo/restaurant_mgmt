using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant_mgmt.Core.Helpers;
using Restaurant_mgmt.Core.Interfaces;
using Restaurant_mgmt.Dal.Data;
using Restaurant_mgmt.Dal.Services;

namespace Restaurant_mgmt.Dal.Extensions;

public static class ApplicationDalExtensions
{
    public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql(config.GetConnectionString("restaurantMgmtDb"));
        });

        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

        return services;
    }
}