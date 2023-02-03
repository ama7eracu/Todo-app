using Microsoft.EntityFrameworkCore;
using TodoApp.Persistence;

namespace TodoApp.Tests.Common;

using Todo.Domain;

public class TodoAppContextFactory
{
   
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();
    
    //Lists
    public static Guid TodoListForDelete = Guid.NewGuid();
    public static Guid TodoListForUpdate = Guid.NewGuid();
    
    //Items
    public static Guid TodoItemForDelete { get; set; }
    public static Guid TodoItemForUpdate { get; set; }
  
    
    public static TodoDbContext Create()
    {
        var options = new DbContextOptionsBuilder<TodoDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new TodoDbContext(options);
        context.Database.EnsureCreated();
        context.TodoLists.AddRange(
            new TodoList
            {
                Title = "Title 1",
                Description = "Description 1",
                Id = Guid.Parse("29A34F36-470B-4471-A6EA-1E5BF50093DE"),
                Items = Seed.DeleteList,
                UserId = UserAId
            },
            new TodoList
            {
                Title = "Title 2",
                Description = "Description 2",
                Id = Guid.Parse("A03A396E-A4FC-4960-B505-1340FAC0662A"),
                Items = Seed.UpdateList,
                UserId = UserBId
            },
            new TodoList
            {
                Title = "Title 3",
                Description = "Description 3",
                Id = TodoListForDelete,
                Items = Seed.DeleteList,
                UserId = UserAId
            },
            new TodoList
            {
                Title = "Title 4",
                Description = "Description 4",
                Id = TodoListForUpdate,
                Items = Seed.UpdateList,
                UserId = UserAId
            }
        );

        context.SaveChanges();

        return context;
    }

    public static void Destroy(TodoDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}