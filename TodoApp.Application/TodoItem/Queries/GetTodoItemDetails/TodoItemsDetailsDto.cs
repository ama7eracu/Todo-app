using AutoMapper;
namespace TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;

public class TodoItemsDetailsDto:Profile
{
    public Guid Id { get; set; }
    public string  Description { get; set; }
    public string  Title { get; set; }
    public bool Done { get; set; }

    public TodoItemsDetailsDto()
    {
        CreateMap<TodoItemsDetailsDto, Todo.Domain.TodoItem>().ReverseMap();
    }
}