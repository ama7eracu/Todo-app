using MediatR;

namespace TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;

public class GetTodoItemDetailsQuery:IRequest<TodoItemsDetailsDto>
{
    public Guid ListId { get; set; }
    public Guid Id { get; set; }
}