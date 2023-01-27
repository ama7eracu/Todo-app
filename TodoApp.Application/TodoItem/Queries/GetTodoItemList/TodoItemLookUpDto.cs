using AutoMapper;

namespace TodoApp.Application.TodoItem.Queries.GetTodoItemList;

public class TodoItemLookUpDto:Profile
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool Done { get; set; }

    public TodoItemLookUpDto()
    {
        CreateMap<TodoItemLookUpDto, Todo.Domain.TodoItem>().ReverseMap();
    }
}