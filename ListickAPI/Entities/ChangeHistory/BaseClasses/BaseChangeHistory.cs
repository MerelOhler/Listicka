using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities.ChangeHistory.BaseClasses;

public class BaseChangeHistory
{
    [MaxLength(16)]
    public required string EventType { get; set; }

    [MaxLength(100)]
    public required string ColumnName { get; set; }

    public string? OriginalValue { get; set; } = null!;

    public string? NewValue { get; set; } = null!;
    public required LoginUser ModifiedBy { get; set; }

    public required DateTime DateModified { get; set; }
}
