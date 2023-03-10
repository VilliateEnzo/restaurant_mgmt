using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant_mgmt.Core.Entities;
using Restaurant_mgmt.Core.Enums;

namespace Restaurant_mgmt.Dal.Data;

public class DataContext : IdentityDbContext <AppUser, AppRole, Guid, IdentityUserClaim<Guid>, 
    AppUserRole, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public DataContext()
    {
    }
    public DataContext(DbContextOptions<DataContext> options) : base(options){}

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Restaurant?> Restaurants { get; set; }
    public DbSet<HistoryChange> HistoryChanges { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<RecipeProduct> RecipeProducts { get; set; }
    public DbSet<RestaurantUser> RestaurantUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("restaurantMgmtDb");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.HasPostgresEnum<QuantityUnitEnum>();
        modelBuilder.HasPostgresEnum<RecipeTypeEnum>();
        modelBuilder.HasPostgresEnum<ActionEnum>();
        modelBuilder.HasPostgresEnum<EntityTypeEnum>();
        modelBuilder.HasPostgresEnum<RecipeStatusEnum>();
    }
}