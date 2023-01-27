using AutoMapper;
namespace TodoApp.Application.TodoList.Queries.GetTodoListDetails;

public class TodoListDetailsDto:Profile
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string  Description { get; set; }

    public TodoListDetailsDto()
    {
        CreateMap<TodoListDetailsDto, Todo.Domain.TodoList>().ReverseMap();
    }
}