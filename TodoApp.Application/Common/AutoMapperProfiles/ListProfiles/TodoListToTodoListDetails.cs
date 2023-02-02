using AutoMapper;
using TodoApp.Application.TodoList.Queries.GetTodoListDetails;

namespace TodoApp.Application.Common.AutoMapperProfiles.ListProfiles;

public class TodoListToTodoListDetails : Profile
{
    public TodoListToTodoListDetails()
    {
        CreateMap<TodoListDetailsDto, Todo.Domain.TodoList>().ReverseMap();
    }
}