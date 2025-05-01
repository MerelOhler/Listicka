using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.DataObjects;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public required string UserName { get; set; }
    public required string Password { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Language { get; set; } = null!;
}
