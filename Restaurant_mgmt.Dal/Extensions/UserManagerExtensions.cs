using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Dal.Extensions;

public static class UserManagerExtensions
{
    public static async Task<AppUser> FindUserByClaimsPrincipleEmail(this UserManager<AppUser> userManager,
        ClaimsPrincipal user)
    {
        return await userManager.Users
            .SingleOrDefaultAsync(x => x.Email == user.FindFirstValue(ClaimTypes.Email));
    }
}