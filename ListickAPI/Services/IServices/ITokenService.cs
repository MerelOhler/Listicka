using System;
using ListickAPI.Entities;

namespace ListickAPI.Services.IServices;

public interface ITokenService
{
    string CreateToken(LoginUser user);
}
