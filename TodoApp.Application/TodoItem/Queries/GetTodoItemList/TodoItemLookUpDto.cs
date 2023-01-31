namespace TodoApp.Application.TodoItem.Queries.GetTodoItemList;

public class TodoItemLookUpDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool Done { get; set; }
    
}