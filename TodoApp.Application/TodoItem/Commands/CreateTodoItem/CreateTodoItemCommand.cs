using MediatR;

namespace TodoApp.Application.TodoItem.Commands.CreateTodoItem;

public class CreateTodoItemCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid ListId { get; set; }

    public Guid UserId { get; set; }
}