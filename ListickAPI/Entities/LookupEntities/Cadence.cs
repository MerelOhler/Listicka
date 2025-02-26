using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities.LookupEntities;

public class Cadence
{
    [Key]
    public int CadenceId { get; set; }

    [MaxLength(100)]
    public required string CadenceNameKey { get; set; }

    [MaxLength(512)]
    public required string CadenceDescription { get; set; }
}
