using Restaurant_mgmt.Core.DTOs;

namespace Restaurant_mgmt.Core.Interfaces;

public interface IUserService
{
    Task<UserDto> Register(RegisterDto request);

    Task<UserDto> Login(LoginDto request);
}