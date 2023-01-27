using MediatR;
namespace TodoApp.Application.TodoList.Commands.UpdateTodoList;

public class UpdateTodoListCommand:IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}