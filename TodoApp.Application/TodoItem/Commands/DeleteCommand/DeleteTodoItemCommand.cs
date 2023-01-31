using MediatR;

namespace TodoApp.Application.TodoItem.Commands.DeleteCommand;

public class DeleteTodoItemCommand:IRequest
{
    public Guid Id { get; set; }
    public Guid ListId { get; set; }
    
    public Guid UserId { get; set; }
}