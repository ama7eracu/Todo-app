using Microsoft.EntityFrameworkCore;
using Todo.Domain;
using TodoApp.Application.Interfaces;

namespace TodoApp.Persistence;

public class TodoDbContext:DbContext,ITodoDbContext
{
    public DbSet<TodoItem> Items { get; set; }
    public DbSet<TodoList> TodoLists { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options):
        base(options){}

    protected override void OnModelCreating(ModelBuilder builder)
    { 
        base.OnModelCreating(builder);
        builder.Entity<TodoItem>().HasKey(item => item.Id);
        builder.Entity<TodoItem>().HasIndex(item => item.Id).IsUnique();
        builder.Entity<TodoItem>().Property(item => item.Title).HasMaxLength(100);
        builder.Entity<TodoList>().HasKey(list => list.Id);
        builder.Entity<TodoList>().HasIndex(list => list.Id).IsUnique();
        builder.Entity<TodoList>().Property(list => list.Title).HasMaxLength(200);
    }
}