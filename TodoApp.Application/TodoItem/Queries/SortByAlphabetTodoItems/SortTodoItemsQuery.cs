using MediatR;
namespace TodoApp.Application.TodoItem.Queries.SortTodoItems;

public class SortTodoItemsQuery:IRequest<SortTodoItemsVm>
{
    public Guid UserID { get; set; }
    public Guid ListId { get; set; }
}