using ListickAPI.Data;
using ListickAPI.DataObjects;
using ListickAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ListickAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController(DataContext context) : BaseListickaController
    {
        [HttpPost("create")]
        public async Task<ActionResult<ToDoDto>> Create(ToDoDto toDoDto)
        {
            var user = await context.LoginUser.FirstOrDefaultAsync(u =>
                u.LoginUserId == toDoDto.LoginUserId
            );
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }
            var toDo = new ToDo
            {
                ToDoName = toDoDto.ToDoName,
                Description = toDoDto.Description,
                StartDate = toDoDto.StartDate,
                EndDate = toDoDto.EndDate,
                TimeNeeded = toDoDto.TimeNeeded,
                ColorHexCode = toDoDto.ColorHexCode,
                Notes = toDoDto.Notes,
                PercentComplete = toDoDto.PercentComplete,
                CreatedBy = user,
                DateCreated = DateTime.UtcNow,
            };
            context.ToDo.Add(toDo);
            await context.SaveChangesAsync();
            return Ok(toDoDto);
        }
    }
}
