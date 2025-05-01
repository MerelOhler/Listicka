using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities.LookupEntities;

public class Country
{
    [Key]
    public int CountryId { get; set; }

    [MaxLength(50)]
    public required string CountryName { get; set; }

    [MaxLength(10)]
    public required string CountryCode { get; set; }

    [MaxLength(150)]
    public string? FlagIconUrl { get; set; }

    [MaxLength(10)]
    public string? CurrencySymbol { get; set; } = null!;

    [MaxLength(3)]
    public string? CurrencyCode { get; set; } = null!;

    public bool BeforeAmount { get; set; } = false;
}
