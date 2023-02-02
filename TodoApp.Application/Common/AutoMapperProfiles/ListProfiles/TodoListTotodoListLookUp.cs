using AutoMapper;
using TodoApp.Application.TodoList.Queries.GetTodoListFullList;

namespace TodoApp.Application.Common.AutoMapperProfiles.ListProfiles;

public class TodoListToTodoListLookUp : Profile
{
    public TodoListToTodoListLookUp()
    {
        CreateMap<TodoListLookUpDto, Todo.Domain.TodoList>().ReverseMap();
    }
}