using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using Todo.WebApi.Models;
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

    private IMapper _mapper;
    public ItemsController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet("{Listid}/items")]
    public async Task<ActionResult<TodoItemVm>> GetAllItems(Guid Listid)
    {
        var query = new GetTodoItemListQuery
        {
            ListId = Listid
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
    public async Task<ActionResult<Guid>> CreateItem( CreateTodoItemDto createTodoItemDto,Guid ListId)
    {
        var command = _mapper.Map<CreateTodoItemCommand>(createTodoItemDto);
        command.ListId = ListId;
        command.UserId = UserId;
        var itemID = await Mediator.Send(command);
        return itemID;
    }
    
    [HttpPut("{ListID}/items")]
    public async Task<IActionResult> UpdateItem(UpdateTodoItemDto updateTodoItemDto,Guid ListID)
    {
        var command = _mapper.Map<UpdateTodoItemCommand>(updateTodoItemDto);
        command.UserId = UserId;
        await Mediator.Send(command);
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