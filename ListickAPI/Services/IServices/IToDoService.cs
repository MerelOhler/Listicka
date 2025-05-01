using System;
using ListickAPI.DataObjects;
using ListickAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListickAPI.Services.IServices;

public interface IToDoService
{
    public Task<ToDoDto> Create(ToDoDto toDoDto);
    public Task<ToDoDto?> GetById(int id);
    public Task<List<ToDoDto>> GetByUserId(
        int userId,
        int page = 1,
        int pageSize = 10,
        string? search = null,
        bool? completed = null
    );
}
