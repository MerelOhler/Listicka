using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities;

public class LoginUser
{
    [Key]
    public int LoginUserId { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string PasswordSalt { get; set; }
}
