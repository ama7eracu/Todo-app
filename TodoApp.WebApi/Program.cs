using Todo.WebApi.Models;
using TodoApp.Application;
using TodoApp.Application.Common.AutoMapperProfiles.ItemsProfiles;
using TodoApp.Application.Common.AutoMapperProfiles.ListProfiles;
using TodoApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();

services.AddHttpContextAccessor();
services.AddAutoMapper(typeof(TodoItemToTodoItemDetails), typeof(TodoItemToTodoItemLookUp),
    typeof(CreateTodoLIstDtoProfile),
    typeof(UpdateTodoListDtoProfile), typeof(TodoListToTodoListDetails), typeof(TodoListToTodoListLookUp));
services.AddControllers();
services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<TodoDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
    }
}

app.Run();