using AutoMapper;
using TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;

namespace TodoApp.Application.Common.AutoMapperProfiles.ItemsProfiles;

public class TodoItemToTodoItemDetails:Profile {
    public TodoItemToTodoItemDetails()
    {
        CreateMap<TodoItemsDetailsDto,Todo.Domain.TodoItem>().ReverseMap();
    }
}