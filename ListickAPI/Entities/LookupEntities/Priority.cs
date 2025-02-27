using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities.LookupEntities;

public class Priority
{
    [Key]
    public int PriorityId { get; set; }

    [MaxLength(100)]
    public required string PriorityNameKey { get; set; }

    [MaxLength(512)]
    public required string PriorityDescription { get; set; }
}
