using MediatR;

namespace TodoApp.Application.TodoItem.Queries.GetTodoItemList;

public class GetTodoItemListQuery : IRequest<TodoItemVm>
{
    public Guid ListId { get; set; }
    public Guid UserId { get; set; }
}