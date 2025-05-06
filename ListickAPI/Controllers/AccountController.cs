using ListickAPI.Data;
using ListickAPI.DataObjects;
using ListickAPI.Entities;
using ListickAPI.Entities.LookupEntities;
using ListickAPI.Services.IServices;
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
            var user = await context
                .LoginUser.Include(lu => lu.Language)
                .FirstOrDefaultAsync(u => u.UserName == loginDto.UserName.ToLower());
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            if (!VerifyPasswordHash(user.PasswordHash, user.PasswordSalt, loginDto.Password))
            {
                return Unauthorized("Invalid username or password");
            }
            return Ok(
                new UserDto
                {
                    LoginUserId = user.LoginUserId,
                    UserName = user.UserName,
                    Token = tokenService.CreateToken(user),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Language = user.Language,
                }
            );
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var existingUser = await context
                .LoginUser.Include(lu => lu.Language)
                .FirstOrDefaultAsync(u => u.UserName == registerDto.UserName.ToLower());
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
                            LoginUserId = existingUser.LoginUserId,
                            UserName = existingUser.UserName,
                            Token = tokenService.CreateToken(existingUser),
                            FirstName = existingUser.FirstName,
                            LastName = existingUser.LastName,
                            Email = existingUser.Email,
                            Language = existingUser.Language,
                        }
                    );
                }
            }
            CreatePasswordHash(
                registerDto.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt
            );
            Language lang =
                context.Language.FirstOrDefault(l =>
                    l.LanguageId == registerDto.Language.LanguageId
                ) ?? context.Language.FirstOrDefault(l => l.LanguageId == 1)!;
            var user = new LoginUser
            {
                UserName = registerDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = registerDto.UserName,
                FirstName = registerDto.FirstName,
                DateCreated = DateTime.UtcNow,
                Language = lang,
            };

            context.LoginUser.Add(user);
            await context.SaveChangesAsync();
            return Ok(
                new UserDto
                {
                    LoginUserId = user.LoginUserId,
                    UserName = user.UserName,
                    Token = tokenService.CreateToken(user),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Language = user.Language,
                }
            );
        }

        [HttpPut("{id}/language")]
        public async Task<ActionResult<UserDto>> UpdateLanguage(int id, Language language)
        {
            var user = await context.LoginUser.FirstOrDefaultAsync(u => u.LoginUserId == id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var lang = await context.Language.FirstOrDefaultAsync(l =>
                l.LanguageId == language.LanguageId
            );
            if (lang == null)
            {
                return NotFound("Language not found");
            }

            user.Language = lang;
            await context.SaveChangesAsync();
            return Ok(
                new UserDto
                {
                    LoginUserId = user.LoginUserId,
                    UserName = user.UserName,
                    Token = tokenService.CreateToken(user),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Language = user.Language,
                }
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
