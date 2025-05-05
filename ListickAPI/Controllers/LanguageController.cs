using ListickAPI.Data;
using ListickAPI.Entities.LookupEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : BaseListickaController
    {
        private readonly DataContext _context;

        public LanguageController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            var query = _context.Language.Where(l => l.IsActive == true);
            var languages = await query.ToListAsync();
            return Ok(languages);
        }
    }
}
