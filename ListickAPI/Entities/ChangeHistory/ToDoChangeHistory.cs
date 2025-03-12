using System;
using System.ComponentModel.DataAnnotations;
using ListickAPI.Entities.ChangeHistory.BaseClasses;

namespace ListickAPI.Entities.ChangeHistory;

public class ToDoChangeHistory : BaseChangeHistory
{
    [Key]
    public int ToDoChangeHistoryId { get; set; }

    public required ToDo ToDo { get; set; }
}
