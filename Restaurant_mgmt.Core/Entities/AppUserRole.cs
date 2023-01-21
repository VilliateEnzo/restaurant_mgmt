using Microsoft.AspNetCore.Identity;

namespace Restaurant_mgmt.Core.Entities;

public class AppUserRole : IdentityUserRole<Guid>
{
    public AppUser User { get; set; }
    public AppRole Role { get; set; }
}