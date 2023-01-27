using AutoMapper;
namespace TodoApp.Application.TodoList.Queries.GetTodoListFullList;

public class TodoListLookUpDto:Profile
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    
    public TodoListLookUpDto()
    {
        CreateMap<TodoListLookUpDto, Todo.Domain.TodoList>().ReverseMap();
    }
}