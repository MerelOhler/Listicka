using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities.LookupEntities;

public class Priority
{
    [Key]
    public int PriorityId { get; set; }

    [MaxLength(100)]
    public required string PriorityNameKey { get; set; }

    [MaxLength(100)]
    public required string PriorityName { get; set; }

    [MaxLength(512)]
    public required string PriorityDescription { get; set; }

    public required string ColorHexCode { get; set; }

    public required int SortOrder { get; set; }

    public required bool IsActive { get; set; }

    public required bool IsDefault { get; set; }
    public LoginUser? CreatedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public LoginUser? ModifiedBy { get; set; } = null!;
    public DateTime? DateModified { get; set; }
    public LoginUser? DeletedBy { get; set; } = null!;
    public DateTime? DateDeleted { get; set; }
}
