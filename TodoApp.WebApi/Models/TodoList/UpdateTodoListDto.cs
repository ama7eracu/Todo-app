using AutoMapper;
using Todo.Domain;
using TodoApp.Application.TodoList.Commands.UpdateTodoList;

namespace Todo.WebApi.Models;

public class UpdateTodoListDto:Profile
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string  Description { get; set; }

    public UpdateTodoListDto()
    {
        CreateMap<UpdateTodoListDto,UpdateTodoListCommand>().ReverseMap();
    }
}