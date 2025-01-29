using ListickAPI.Data;
using ListickAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(DataContext context) : BaseListickaController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginUser>>> Get()
        {
            var users = await context.LoginUser.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoginUser>> GetUser(int id)
        {
            var user = await context.LoginUser.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
