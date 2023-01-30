using AutoMapper;
using TodoApp.Application.TodoList.Commands.CreateTodoList;

namespace Todo.WebApi.Models;

public class CreateTodoLIstDtoProfile:Profile
{
    public CreateTodoLIstDtoProfile()
    {
        CreateMap<CreateTodoListDto, CreateTodoListCommand>().ReverseMap();
    }
}