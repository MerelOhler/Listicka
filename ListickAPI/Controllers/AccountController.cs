using ListickAPI.Data;
using ListickAPI.DataObjects;
using ListickAPI.Entities;
using ListickAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(DataContext context, ITokenService tokenService)
        : BaseListickaController
    {
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.LoginUser.FirstOrDefaultAsync(u =>
                u.UserName == loginDto.UserName.ToLower()
            );
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            if (!VerifyPasswordHash(user.PasswordHash, user.PasswordSalt, loginDto.Password))
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(
                new UserDto { UserName = user.UserName, Token = tokenService.CreateToken(user) }
            );
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var existingUser = await context.LoginUser.FirstOrDefaultAsync(u =>
                u.UserName == registerDto.UserName.ToLower()
            );
            if (existingUser != null)
            {
                if (
                    !VerifyPasswordHash(
                        existingUser.PasswordHash,
                        existingUser.PasswordSalt,
                        registerDto.Password
                    )
                )
                {
                    return Unauthorized("Invalid username or password");
                }
                else
                {
                    return Ok(
                        new UserDto
                        {
                            UserName = existingUser.UserName,
                            Token = tokenService.CreateToken(existingUser),
                        }
                    );
                }
            }
            CreatePasswordHash(
                registerDto.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt
            );
            var user = new LoginUser
            {
                UserName = registerDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = registerDto.UserName,
            };

            context.LoginUser.Add(user);
            await context.SaveChangesAsync();
            return Ok(
                new UserDto { UserName = user.UserName, Token = tokenService.CreateToken(user) }
            );
        }

        private void CreatePasswordHash(
            string password,
            out byte[] passwordHash,
            out byte[] passwordSalt
        )
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(byte[] passwordHash, byte[] passwordSalt, string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
