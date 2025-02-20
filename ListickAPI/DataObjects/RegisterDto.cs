using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.DataObjects;

public class RegisterDto
{
    [Required]
    [MaxLength(100)]
    public required string UserName { get; set; }
    public required string Password { get; set; }

    public required string Name { get; set; }
}
