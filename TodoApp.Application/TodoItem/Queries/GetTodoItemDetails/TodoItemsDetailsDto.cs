namespace TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;
public class TodoItemsDetailsDto
{
    public Guid Id { get; set; }
    public string  Description { get; set; }
    public string  Title { get; set; }
    public bool Done { get; set; }
    
}