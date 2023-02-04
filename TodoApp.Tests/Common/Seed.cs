namespace TodoApp.Tests.Common;

using Todo.Domain;

public static class Seed
{
    public static readonly List<TodoItem> DeleteList = new List<TodoItem>()
    {
        new TodoItem
        {
            Description = "Description 1",
            Title = "Title 1",
            Done = false,
            Id = TodoAppContextFactory.TodoItemForDelete,
            UserId = TodoAppContextFactory.UserAId,
            TodoListId = TodoAppContextFactory.TodoListForDelete
        }
    };

    public static readonly List<TodoItem> UpdateList = new List<TodoItem>()
    {
        new TodoItem
        {
            Description = "Description 2",
            Title = "Title 2",
            Done = false,
            Id = TodoAppContextFactory.TodoItemForUpdate,
            UserId = TodoAppContextFactory.UserAId,
            TodoListId = TodoAppContextFactory.TodoListForUpdate
        }
    };
}