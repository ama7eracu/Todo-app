using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.WebApi.Models;
using TodoApp.Application.TodoList.Commands.CreateTodoList;
using TodoApp.Application.TodoList.Commands.DeleteCommandsTodoList;
using TodoApp.Application.TodoList.Commands.UpdateTodoList;
using TodoApp.Application.TodoList.Queries.GetTodoListDetails;
using TodoApp.Application.TodoList.Queries.GetTodoListFullList;

namespace Todo.WebApi.Controllers;
[Route("api/[controller]")]
public class TodoController:BaseController
{
    private readonly IMapper _mapper;
    
    public TodoController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<TodoListVm>> GetAllList()
    {
        var query = new GetTodoListsFullListQuery
        {
            UserId = UserId
        };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoListDetailsDto>> GetList(Guid id)
    {
        var query = new GetTodoListDetailsQuery
        {
            Id = id,
            UserId = UserId
        };
        var vm = Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateList([FromBody] CreateTodoListDto createTodoListDto)
    {
        var command = _mapper.Map<CreateTodoListCommand>(createTodoListDto);
        command.UserId = UserId;
        var ListId = await Mediator.Send(command);
        return Ok(ListId); 
    }

    [HttpPut]
    public async Task<IActionResult> UpdateList([FromBody] UpdateTodoListDto updateTodoListDto)
    {
        var command = _mapper.Map<UpdateTodoListCommand>(updateTodoListDto);
        command.UserId = UserId;
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteList(Guid id)
    {
        var Command = new DeleteTodoListCommand
        {
            Id = id,
            UserId = UserId
        };
        await Mediator.Send(Command);
        return NoContent();
    }
}