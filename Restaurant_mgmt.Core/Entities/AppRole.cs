using Microsoft.AspNetCore.Identity;

namespace Restaurant_mgmt.Core.Entities;

public class AppRole : IdentityRole<Guid>
{
    public ICollection<AppUserRole> UserRoles { get; set; } 
}