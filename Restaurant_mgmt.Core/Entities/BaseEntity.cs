namespace Restaurant_mgmt.Core.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public AppUser CreatedBy { get; set; }
    
    public Guid CreatedById { get; set; }

    public bool IsDeleted { get; set; } = false;
    
    public DateTime CreatedAt { get; set; }

    public List<HistoryChange> HistoryChanges { get; set; } = new List<HistoryChange>();
}