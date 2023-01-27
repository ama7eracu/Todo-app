using MediatR;

namespace TodoApp.Application.TodoList.Queries.GetTodoListFullList;

public class GetTodoListsFullListQuery:IRequest<TodoListVm>
{ 
    public Guid UserId { get; set; }
}