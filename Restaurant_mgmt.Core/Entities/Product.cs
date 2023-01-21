using Restaurant_mgmt.Core.Enums;

namespace Restaurant_mgmt.Core.Entities;

public class Product
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; } = string.Empty;
    
    public ProductType Type { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public ProductStatusEnum Status { get; set; } = ProductStatusEnum.InStock;

    public AppUser CreatedBy { get; set; }
    
    public Guid CreatedById { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<HistoryChange> HistoryChanges { get; set; } = new List<HistoryChange>();
    
    public Restaurant Restaurant { get; set; }

    public Guid RestaurantId { get; set; }

    public bool IsDeleted { get; set; } = false;

    public string ImgUrl { get; set; } = string.Empty;
}

