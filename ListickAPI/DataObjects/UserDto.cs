using System;
using ListickAPI.Entities.LookupEntities;

namespace ListickAPI.DataObjects;

public class UserDto
{
    public required int LoginUserId { get; set; }
    public required string UserName { get; set; }
    public string? Token { get; set; } = null!;
    public required string FirstName { get; set; }
    public string? LastName { get; set; } = null!;
    public required string Email { get; set; }
    public required Language Language { get; set; }

    //                     Email = toDo.CreatedBy.Email,
    //                     PhoneNumber = toDo.CreatedBy.PhoneNumber,
    //                     ProfilePictureUrl = toDo.CreatedBy.ProfilePictureUrl
    //                     Language = toDo.CreatedBy.Language,
}
