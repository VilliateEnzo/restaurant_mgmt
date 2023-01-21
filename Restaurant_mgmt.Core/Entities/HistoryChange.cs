using System.ComponentModel.DataAnnotations;
using Restaurant_mgmt.Core.Enums;

namespace Restaurant_mgmt.Core.Entities;

public class HistoryChange
{
    public Guid Id { get; set; }

    public DateTime Date { get; set; }

    public AppUser User { get; set; }
    
    public Guid UserId { get; set; }

    public ActionEnum Action { get; set; }

    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
}

