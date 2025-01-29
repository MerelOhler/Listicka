using System;
using System.ComponentModel.DataAnnotations;

namespace ListickAPI.Entities;

public class LoginUser
{
    [Key]
    public int LoginUserId { get; set; }

    [MaxLength(100)]
    public required string UserName { get; set; }

    [MaxLength(512)]
    public required byte[] PasswordHash { get; set; }

    [MaxLength(512)]
    public required byte[] PasswordSalt { get; set; }

    [MaxLength(100)]
    public required string Email { get; set; }

}
