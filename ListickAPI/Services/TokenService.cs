using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ListickAPI.Entities;
using ListickAPI.Services.IServices;
using Microsoft.IdentityModel.Tokens;

namespace ListickAPI.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(LoginUser user)
    {
        string tokenKey =
            config["TokenKey"] ?? throw new Exception("Cannot access tokenKey from appsettings");
        if (tokenKey.Length < 64)
            throw new Exception("TokenKey must be at least 64 characters long");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.UserName) };
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds,
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
