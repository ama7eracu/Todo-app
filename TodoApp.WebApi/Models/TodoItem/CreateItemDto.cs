namespace Todo.WebApi.Models.TodoItem;

public class CreateItemDto
{
    public Guid ListId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
    
}