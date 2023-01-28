using Todo.WebApi.Models;
using TodoApp.Application;
using TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;
using TodoApp.Application.TodoList.Queries.GetTodoListDetails;
using TodoApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();

services.AddHttpContextAccessor();
services.AddAutoMapper(typeof(TodoListDetailsDto), typeof(TodoItemsDetailsDto),typeof(CreateTodoListDto),typeof(UpdateTodoListDto));
services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
//app.UseWelcomePage();
app.MapControllers();

using (var scope=app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<TodoDbContext>();
        DbInitializer.Initialize(context);
    }
    catch(Exception exception)
    {
         
    }
}
app.Run();