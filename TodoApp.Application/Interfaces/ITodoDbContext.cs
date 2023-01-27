using Microsoft.EntityFrameworkCore;
using Todo.Domain;

namespace TodoApp.Application.Interfaces;

public interface ITodoDbContext
{
    DbSet<TodoItem> Items { get; set; }
    DbSet<Todo.Domain.TodoList> TodoLists { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}