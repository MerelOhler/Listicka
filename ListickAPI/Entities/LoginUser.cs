using System;
using System.ComponentModel.DataAnnotations;
using ListickAPI.Entities.LookupEntities;
using Microsoft.CodeAnalysis;

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

    [MaxLength(100)]
    public required string FirstName { get; set; }

    [MaxLength(100)]
    public string? LastName { get; set; } = null!;

    [MaxLength(15)]
    public string? PhoneNumber { get; set; } = null!;
    public string? StreetAddress { get; set; } = null!;
    public string? AptSuite { get; set; } = null!;
    public string? City { get; set; } = null!;
    public string? StateProvince { get; set; } = null!;
    public string? ZipCode { get; set; } = null!;
    public string? Country { get; set; } = null!;
    public string? TimeZone { get; set; } = null!;

    public Language Language { get; set; } = null!;
    public string? Currency { get; set; } = null!;
    public string? DateFormat { get; set; } = null!;
    public string? TimeFormat { get; set; } = null!;
    public WeekDays? WeekStart { get; set; } = null!;
    public required DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public int? ModifiedBy { get; set; } = null!;
    public DateTime? DateModified { get; set; } = null!;
    public int? DeletedBy { get; set; } = null!;
    public DateTime? DateDeleted { get; set; } = null!;
    public string? ProfilePictureUrl { get; set; } = null!;
}
