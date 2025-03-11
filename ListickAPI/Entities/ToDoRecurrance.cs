using System;
using System.ComponentModel.DataAnnotations;
using ListickAPI.Entities.LookupEntities;

namespace ListickAPI.Entities;

public class ToDoRecurrance
{
    [Key]
    public int ToDoRecurranceId { get; set; }

    [MaxLength(100)]
    public required string ToDoName { get; set; }

    [MaxLength(512)]
    public string? Description { get; set; } = null!;
    public DateTime? StartDate { get; set; } = null!;
    public DateTime? EndDate { get; set; } = null!;
    public short? TimeNeeded { get; set; } = null!;
    public Project? Project { get; set; } = null!;
    public Status? Status { get; set; } = null!;
    public Priority? Priority { get; set; } = null!;

    [MaxLength(64)]
    public string? ColorHexCode { get; set; } = null!;
    public string? RecurringNotes { get; set; } = null!;
    public required Cadence Cadence { get; set; }
    public List<WeekDays> WeekDays { get; set; } = null!;
    public required LoginUser CreatedBy { get; set; }
    public DateTime DateCreated { get; set; }
    public LoginUser? ModifiedBy { get; set; } = null!;
    public DateTime? DateModified { get; set; } = null!;
    public LoginUser? DeletedBy { get; set; } = null!;
    public DateTime? DateDeleted { get; set; } = null!;
}
