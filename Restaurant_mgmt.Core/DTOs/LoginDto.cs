using System.ComponentModel.DataAnnotations;

namespace Restaurant_mgmt.Core.DTOs;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    [MinLength(6)]
    public string Password { get; set; }
}