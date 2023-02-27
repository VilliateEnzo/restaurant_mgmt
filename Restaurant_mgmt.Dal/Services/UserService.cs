using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant_mgmt.Core.DTOs;
using Restaurant_mgmt.Core.Entities;
using Restaurant_mgmt.Core.Errors;
using Restaurant_mgmt.Core.Exceptions;
using Restaurant_mgmt.Core.Interfaces;

namespace Restaurant_mgmt.Dal.Services;

public class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public UserService(UserManager<AppUser> userManager, IMapper mapper, ITokenService tokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _tokenService = tokenService;
    }
    public async Task<UserDto> Register(RegisterDto request)
    {
        if (await UserExist(request.Email)) throw new EntityAlreadyExistsException("User");

        AppUser user = _mapper.Map<AppUser>(request);
        user.UserName = request.Username.ToLower();

        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        
        if (!result.Succeeded) throw new ApiException(400, "Bad request", "Error");
        
        //IdentityResult roleResult = await _userManager.AddToRoleAsync(user, "Member");
        
        //if(!roleResult.Succeeded) throw new ApiException(400, "Bad request", "Error");

        //todo: add token and photo url
        return new UserDto()
        {
            Username = user.UserName,
            Email = user.Email,
            Token = await _tokenService.CreateToken(user),
            PhotoUrl = "asdassdas"
        };
    }

    public async Task<UserDto> Login(LoginDto request)
    {
        AppUser user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == request.Username.ToLower());

        if (user == null) throw new ApiException(401, "Unauthorized", "Wrong Username or Password");

        bool result = await _userManager.CheckPasswordAsync(user, request.Password);
        
        if (!result) throw new ApiException(401, "Unauthorized", "Wrong Username or Password");
        
        //todo: add token and photo url
        return new UserDto()
        {
            Username = user.UserName,
            Email = user.Email,
            Token = await _tokenService.CreateToken(user),
            PhotoUrl = "asdassdas"
        };
    }

    private async Task<bool> UserExist(string email)
    {
        return await _userManager.Users.AnyAsync(x => x.Email == email.ToLower());
    }
}