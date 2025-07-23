using ListickAPI.Data;
using ListickAPI.Entities.LookupEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Priority>>> Get()
        {
            var priorities = await context.Priority.ToListAsync();
            return Ok(priorities);
        }
    }
}
