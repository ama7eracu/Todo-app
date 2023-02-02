using MediatR;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.TodoList.Commands.CreateTodoList;

public class CreateTodoListHandler
    : IRequestHandler<CreateTodoListCommand, Guid>
{
    private readonly ITodoDbContext _dbContext;

    public CreateTodoListHandler(ITodoDbContext context) =>
        _dbContext = context;

    public async Task<Guid> Handle(CreateTodoListCommand request,
        CancellationToken cancellationToken)
    {
        var TodoList = new Todo.Domain.TodoList
        {
            UserId = request.UserId,
            Title = request.Title,
            Description = request.Description,
            Id = Guid.NewGuid()
        };

        await _dbContext.TodoLists.AddAsync(TodoList, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return TodoList.Id;
    }
}