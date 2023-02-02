using MediatR;

namespace TodoApp.Application.TodoList.Commands.DeleteCommandsTodoList;

public class DeleteTodoListCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}