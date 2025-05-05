using System;
using System.ComponentModel.DataAnnotations;
using ListickAPI.Entities.LookupEntities;

namespace ListickAPI.DataObjects;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public required string UserName { get; set; }
    public required string Password { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required Language Language { get; set; }
}
