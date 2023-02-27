namespace Restaurant_mgmt.Core.Entities;

public class Restaurant : BaseEntity
{
    public string? Ubication { get; set; }

    public ICollection<Recipe>? Recipes { get; set; }
}