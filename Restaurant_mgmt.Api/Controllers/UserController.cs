using Microsoft.AspNetCore.Mvc;
using Restaurant_mgmt.Core.DTOs;
using Restaurant_mgmt.Core.Interfaces;

namespace Restaurant_mgmt.Controllers;

public class UserController : BaseApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("/Register/")]
    public Task<UserDto> Register(RegisterDto request)
    {
        return _userService.Register(request);
    }
    
    [HttpPost("/Login")]
    public Task<UserDto> Login(LoginDto request)
    {
        return _userService.Login(request);
    }
}