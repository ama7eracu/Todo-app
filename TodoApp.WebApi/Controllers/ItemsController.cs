using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.WebApi.Models.TodoItem;
using TodoApp.Application.TodoItem.Commands.CreateTodoItem;
using TodoApp.Application.TodoItem.Commands.DeleteCommand;
using TodoApp.Application.TodoItem.Commands.UpdateTodoItem;
using TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;
using TodoApp.Application.TodoItem.Queries.GetTodoItemList;

namespace Todo.WebApi.Controllers;
[Route("api/Todo")]
public class ItemsController:BaseController
{

    private readonly IMapper _mapper;
    public ItemsController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet("{listId}/items")]
    public async Task<ActionResult<TodoItemVm>> GetAllItems(Guid listId)
    {
        var query = new GetTodoItemListQuery
        {
            ListId = listId
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet("{listId}/items/{id}")]
    public async Task<ActionResult<TodoItemsDetailsDto>> GetItem(Guid listId,Guid id)
    {
        var query = new GetTodoItemDetailsQuery
        {
            Id = id,
            ListId = listId
        };
        var vm =await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpPost("{listId}/items")]
    public async Task<ActionResult<Guid>> CreateItem( CreateTodoItemDto createTodoItemDto,Guid listId)
    {
        var command = _mapper.Map<CreateTodoItemCommand>(createTodoItemDto);
        command.ListId = listId;
        command.UserId = UserId;
        var itemId = await Mediator.Send(command);
        return itemId;
    }
    
    [HttpPut("{listId}/items")]
    public async Task<IActionResult> UpdateItem(UpdateTodoItemDto updateTodoItemDto,Guid listId)
    {
        var command = _mapper.Map<UpdateTodoItemCommand>(updateTodoItemDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("{listId}/items/{id}")]
    public async Task<IActionResult> DeleteItem(Guid id,Guid listId)
    {
        var command = new DeleteTodoItemCommand
        {
            ListId = listId,
            Id = id
        };
        await Mediator.Send(command);
        return NoContent();
    }
    
}