using AutoMapper;
using TodoApp.Application.TodoList.Queries.GetTodoListFullList;

namespace TodoApp.Application.Common.AutoMapperProfiles;
using Todo.Domain;
public class TodoListToTodoListLookUp:Profile
{
    public TodoListToTodoListLookUp()
    {
        CreateMap<TodoListLookUpDto, TodoList>().ReverseMap();
    }
}