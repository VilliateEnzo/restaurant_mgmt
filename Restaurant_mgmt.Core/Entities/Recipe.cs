using Restaurant_mgmt.Core.Enums;

namespace Restaurant_mgmt.Core.Entities;

public class Recipe : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    
    public RecipeTypeEnum TypeEnum { get; set; }

    public decimal Price { get; set; }

    public RecipeStatusEnum Status { get; set; } = RecipeStatusEnum.InStock;

    public Restaurant Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public string ImgUrl { get; set; } = string.Empty;
    
    public ICollection<RecipeProduct> RecipeProducts { get; set; }
}

