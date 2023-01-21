using System.ComponentModel.DataAnnotations;

namespace Restaurant_mgmt.Core.DTOs;

public class RegisterDto
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
    
    [Required]
    public string Username { get; set; }
}