using MediatR;

namespace TodoApp.Application.TodoList.Queries.GetTodoListDetails;

public class GetTodoListDetailsQuery : IRequest<TodoListDetailsDto>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}