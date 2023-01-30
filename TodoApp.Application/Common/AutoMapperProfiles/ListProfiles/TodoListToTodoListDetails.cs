using AutoMapper;
using TodoApp.Application.TodoList.Queries.GetTodoListDetails;

namespace TodoApp.Application.Common.AutoMapperProfiles;
using Todo.Domain;
public class TodoListToTodoListDetails:Profile
{
    public TodoListToTodoListDetails()
    {
        CreateMap<TodoListDetailsDto, TodoList>().ReverseMap();
    }
}