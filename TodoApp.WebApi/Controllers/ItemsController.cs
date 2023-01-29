using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.TodoItem.Commands.CreateTodoItem;
using TodoApp.Application.TodoItem.Commands.DeleteCommand;
using TodoApp.Application.TodoItem.Commands.UpdateTodoItem;
using TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;
using TodoApp.Application.TodoItem.Queries.GetTodoItemList;

namespace Todo.WebApi.Controllers;
[Route("api/Todo")]
public class ItemsController:BaseController
{
    [HttpGet("{id}/items")]
    public async Task<ActionResult<TodoItemVm>> GetAllItems(Guid id)
    {
        var query = new GetTodoItemListQuery
        {
            ListId = id
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpGet("{ListId}/items/{id}")]
    public async Task<ActionResult<TodoItemsDetailsDto>> GetItem(Guid ListId,Guid id)
    {
        var query = new GetTodoItemDetailsQuery
        {
            Id = id,
            ListId = ListId
        };
        var vm =await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpPost("{ListId}/items")]
    public async Task<ActionResult<Guid>> CreateItem( CreateTodoItemCommand createTodoItemCommand,Guid ListId)
    {
        var itemID = await Mediator.Send(createTodoItemCommand);
        return itemID;
    }
    [HttpPut]
    public async Task<IActionResult> UpdateItem([FromBody]UpdateTodoItemCommand updateTodoItemCommand)
    {
        await Mediator.Send(updateTodoItemCommand);
        return NoContent();
    }
    [HttpDelete("{ListId}/items/{id}")]
    public async Task<IActionResult> DeleteItem(Guid id,Guid ListId)
    {
        var command = new DeleteTodoItemCommand
        {
            ListId = ListId,
            Id = id
        };
        await Mediator.Send(command);
        return NoContent();
    }
    
}