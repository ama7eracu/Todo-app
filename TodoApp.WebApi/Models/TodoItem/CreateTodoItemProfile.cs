using AutoMapper;
using TodoApp.Application.TodoItem.Commands.CreateTodoItem;

namespace Todo.WebApi.Models.TodoItem;

public class CreateTodoItemProfile : Profile
{
    public CreateTodoItemProfile()
    {
        CreateMap<CreateTodoItemDto, CreateTodoItemCommand>().ReverseMap();
    }
}