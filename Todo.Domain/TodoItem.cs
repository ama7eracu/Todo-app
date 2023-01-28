namespace Todo.Domain;

public class TodoItem
{
    public Guid ListId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
}