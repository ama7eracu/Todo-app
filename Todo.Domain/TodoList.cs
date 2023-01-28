namespace Todo.Domain;

public class TodoList
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    
    public ICollection<TodoItem> Items { get; set; }
}