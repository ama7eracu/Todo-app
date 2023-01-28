using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Application.Interfaces;

namespace TodoApp.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection
        services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnect"];
        services.AddDbContext<TodoDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        services.AddScoped<ITodoDbContext>(provider =>
        
            provider.GetService<TodoDbContext>());
        return services;
    }
}