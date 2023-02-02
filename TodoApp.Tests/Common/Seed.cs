using Todo.Domain;

namespace TodoApp.Tests.Common;

public static class Seed
{
    public static readonly List<TodoItem> Items1 = new List<TodoItem>()
    {
        new TodoItem
        {
            Description = "Description 1",
            Title = "Title 1",
            Done = false,
            Id = Guid.Parse("FCFCE62B-7492-4DFD-A47C-FB0CDB9A39D7"),
            UserId = TodoAppContextFactory.UserAId,
            TodoListId = Guid.Parse("29A34F36-470B-4471-A6EA-1E5BF50093DE")
        }
    };

    public static readonly List<TodoItem> Items2 = new List<TodoItem>()
    {
        new TodoItem
        {
            Description = "Description 2",
            Title = "Title 2",
            Done = false,
            Id = Guid.Parse("DC29A518-8C49-4C91-9B98-3C5B9AF055C3"),
            UserId = TodoAppContextFactory.UserBId,
            TodoListId = Guid.Parse("A03A396E-A4FC-4960-B505-1340FAC0662A")
        }
    };
}