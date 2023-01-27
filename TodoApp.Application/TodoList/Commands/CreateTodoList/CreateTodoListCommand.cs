using MediatR;
namespace TodoApp.Application.TodoList.Commands.CreateTodoList;

public class CreateTodoListCommand:IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
}