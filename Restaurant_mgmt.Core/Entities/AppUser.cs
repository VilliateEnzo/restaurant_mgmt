using Microsoft.AspNetCore.Identity;

namespace Restaurant_mgmt.Core.Entities;

public class AppUser : IdentityUser<Guid>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    public DateTime LastActiveAt { get; set; } = DateTime.UtcNow;
}