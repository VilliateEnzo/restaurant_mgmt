using System.ComponentModel.DataAnnotations;

namespace Restaurant_mgmt.Core.DTOs;

public class RestaurantDto
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; }

    [MaxLength(200)]
    public string Ubication { get; set; } = string.Empty;
}