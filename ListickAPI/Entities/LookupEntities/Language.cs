using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities.LookupEntities;

public class Language
{
    [Key]
    public int LanguageId { get; set; }

    [MaxLength(50)]
    public string? LanguageName { get; set; } = null!;

    [MaxLength(10)]
    public string? LanguageCode { get; set; } = null!;

    [MaxLength(50)]
    public string? DateFormat { get; set; } = null!;

    [MaxLength(50)]
    public string? TimeFormat { get; set; } = null!;

    [MaxLength(150)]
    public string? FlagIconUrl { get; set; }
}
