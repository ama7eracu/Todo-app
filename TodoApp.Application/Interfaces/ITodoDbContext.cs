using Microsoft.EntityFrameworkCore;

namespace TodoApp.Application.Interfaces;
using Todo.Domain;
public interface ITodoDbContext
{
    DbSet<TodoItem> Items { get; set; }
    DbSet<TodoList> TodoLists { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}