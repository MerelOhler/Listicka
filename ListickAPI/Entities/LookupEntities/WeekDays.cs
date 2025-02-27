using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities.LookupEntities;

public class WeekDays
{
    [Key]
    public int WeekDayId { get; set; }

    [MaxLength(100)]
    public required string WeekDayNameKey { get; set; }

    [MaxLength(512)]
    public required string WeekDayDescription { get; set; }
}
