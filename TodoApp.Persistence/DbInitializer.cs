namespace TodoApp.Persistence;

public class DbInitializer
{
    public static void Initialize(TodoDbContext context)
    {
        context.Database.EnsureCreated();
    }
}