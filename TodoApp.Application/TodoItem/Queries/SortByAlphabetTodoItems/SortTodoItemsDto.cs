namespace TodoApp.Application.TodoItem.Queries.SortTodoItems;

public class SortTodoItemsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool Done { get; set; }
}