using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restaurant_mgmt.Core.Entities;
using Restaurant_mgmt.Core.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Restaurant_mgmt.Dal.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SymmetricSecurityKey _key;
    public TokenService(IConfiguration config, UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"] ?? string.Empty));
    }

    public async Task<string> CreateToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new(JwtRegisteredClaimNames.NameId, user.UserName),
            new(JwtRegisteredClaimNames.Email, user.Email)
        };

        IList<string> roles = await _userManager.GetRolesAsync(user);
        
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        SigningCredentials credentials = new(_key, SecurityAlgorithms.HmacSha512Signature);
        
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = credentials
        };

        JwtSecurityTokenHandler tokenHandler = new();

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}