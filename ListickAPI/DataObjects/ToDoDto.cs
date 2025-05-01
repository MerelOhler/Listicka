using System;

namespace ListickAPI.DataObjects;

public class ToDoDto
{
    public int? ToDoId { get; set; } = null!;
    public required string ToDoName { get; set; }

    public string? Description { get; set; } = null!;
    public DateTime? StartDate { get; set; } = null!;
    public DateTime? EndDate { get; set; } = null!;
    public short? TimeNeeded { get; set; } = null!;
    public string? ColorHexCode { get; set; } = null!;
    public string? Notes { get; set; } = null!;
    public short? PercentComplete { get; set; } = null!;
    public required int LoginUserId { get; set; }
    public UserDto? CreatedBy { get; set; } = null!;
    public DateTime DateCreated { get; set; }
}
