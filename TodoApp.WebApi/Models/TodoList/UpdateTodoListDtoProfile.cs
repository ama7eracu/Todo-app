using AutoMapper;
using TodoApp.Application.TodoList.Commands.UpdateTodoList;

namespace Todo.WebApi.Models;

public class UpdateTodoListDtoProfile : Profile
{
    public UpdateTodoListDtoProfile()
    {
        CreateMap<UpdateTodoListDto, UpdateTodoListCommand>().ReverseMap();
    }
}