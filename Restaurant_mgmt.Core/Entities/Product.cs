using Restaurant_mgmt.Core.Enums;

namespace Restaurant_mgmt.Core.Entities;

public class Product : BaseEntity
{
    public decimal Price { get; set; }
    
    public decimal Quantity { get; set; }
    
    public QuantityUnitEnum QuantityUnit { get; set; }
    
    public ICollection<RecipeProduct>? RecipeProducts { get; set; }
}