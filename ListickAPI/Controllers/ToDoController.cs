using ListickAPI.Data;
using ListickAPI.DataObjects;
using ListickAPI.Services;
using ListickAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ListickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(DataContext context) : BaseListickaController
    {
        readonly IToDoService toDoService = new ToDoService(context);

        [HttpPost("create")]
        public async Task<ActionResult<ToDoDto>> Create(ToDoDto toDoDto)
        {
            try
            {
                ToDoDto dto = await toDoService.Create(toDoDto);
                if (dto == null)
                {
                    return BadRequest("Failed to create ToDo");
                }
                return Ok(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoDto>> GetByID(int id)
        {
            ToDoDto? toDo = await toDoService.GetById(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return Ok(toDo);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<ToDoDto>>> GetByUser(
            int userId,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? search = null,
            [FromQuery] bool? completed = null
        )
        {
            List<ToDoDto> toDos = await toDoService.GetByUserId(
                userId,
                page,
                pageSize,
                search,
                completed
            );
            return Ok(toDos);
        }
    }
}
