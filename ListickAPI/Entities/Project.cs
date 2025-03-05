using System;
using System.ComponentModel.DataAnnotations;
using ListickAPI.Entities.LookupEntities;

namespace ListickAPI.Entities;

public class Project
{
    [Key]
    public int ProjectId { get; set; }

    [MaxLength(100)]
    public required string ProjectName { get; set; }

    [MaxLength(512)]
    public string? Description { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Cadence? Cadence { get; set; } = null!;
    public required LoginUser CreatedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public LoginUser ModifiedBy { get; set; } = null!;
    public DateTime DateModified { get; set; }
    public LoginUser DeletedBy { get; set; } = null!;
    public DateTime DateDeleted { get; set; }
}
