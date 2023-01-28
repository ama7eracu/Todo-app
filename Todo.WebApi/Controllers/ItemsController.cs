using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.TodoItem.Queries.GetTodoItemList;

namespace Todo.WebApi.Controllers;

public class ItemsController:BaseController
{
    [HttpGet]
    public async Task<ActionResult<TodoItemVm>> GetAllItems(Guid id)
    {
        
    }
}