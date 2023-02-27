using Restaurant_mgmt.Core.Enums;

namespace Restaurant_mgmt.Core.Entities;

public class RecipeProduct
{
    public Guid RecipeId { get; set; }
    
    public Recipe Recipe { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; }
    
    public decimal Quantity { get; set; } 
    
    public QuantityUnitEnum QuantityUnit { get; set; }
}