namespace Restaurant_mgmt.Core.Entities;

public class Restaurant
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Ubication { get; set; }

    public bool IsDeleted { get; set; } = false;

    public AppUser CreatedBy { get; set; }
    
    public Guid CreatedById { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<HistoryChange>? HistoryChanges { get; set; }

    public ICollection<Product>? Products { get; set; }
}