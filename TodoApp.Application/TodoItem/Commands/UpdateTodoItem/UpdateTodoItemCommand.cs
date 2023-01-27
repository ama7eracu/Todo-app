using MediatR;
namespace TodoApp.Application.TodoItem.Commands.UpdateTodoItem;

public class UpdateTodoItemCommand:IRequest
{
    public Guid  Id { get; set; }
    public Guid ListId { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public bool Done { get; set; }  
}