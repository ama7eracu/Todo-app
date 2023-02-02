using AutoMapper;
using TodoApp.Application.TodoItem.Queries.GetTodoItemList;

namespace TodoApp.Application.Common.AutoMapperProfiles.ItemsProfiles;

public class TodoItemToTodoItemLookUp : Profile
{
    public TodoItemToTodoItemLookUp()
    {
        CreateMap<TodoItemLookUpDto, Todo.Domain.TodoItem>().ReverseMap();
    }
}