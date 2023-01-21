using Restaurant_mgmt.Core.Entities;

namespace Restaurant_mgmt.Core.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user);
}