namespace Restaurant_mgmt.Core.Entities;

public class RestaurantUser
{
    public Guid Id { get; set; }
    
    public Guid AppUserId { get; set; }
    
    public AppUser AppUser { get; set; }
    
    public Guid RestaurantId { get; set; }
    
    public Restaurant Restaurant { get; set; }

    public string Role { get; set; } = string.Empty;
}