namespace Todo.WebApi.Models.TodoItem;

public class UpdateTodoItemDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
    public Guid Id { get; set; }
    public Guid ListId { get; set; }
}