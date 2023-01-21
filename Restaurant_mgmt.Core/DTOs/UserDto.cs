namespace Restaurant_mgmt.Core.DTOs;

public class UserDto
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Token { get; init; } = string.Empty;
    public string PhotoUrl { get; init; } = string.Empty;
}