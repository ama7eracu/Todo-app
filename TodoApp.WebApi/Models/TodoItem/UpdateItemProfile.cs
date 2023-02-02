using AutoMapper;
using TodoApp.Application.TodoItem.Commands.UpdateTodoItem;

namespace Todo.WebApi.Models.TodoItem;

public class UpdateItemProfile : Profile
{
    public UpdateItemProfile()
    {
        CreateMap<UpdateTodoItemDto, UpdateTodoItemCommand>().ReverseMap();
    }
}