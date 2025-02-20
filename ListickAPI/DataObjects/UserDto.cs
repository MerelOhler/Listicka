using System;

namespace ListickAPI.DataObjects;

public class UserDto
{
    public required string UserName { get; set; }
    public required string Token { get; set; }
    public required string Name { get; set; }
}
