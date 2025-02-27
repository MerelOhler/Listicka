using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities.LookupEntities;

public class Status
{
    [Key]
    public int StatusId { get; set; }

    [MaxLength(100)]
    public required string StatusNameKey { get; set; }

    [MaxLength(512)]
    public required string StatusDescription { get; set; }
}
