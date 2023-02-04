using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.TodoItem.Commands.DeleteCommand;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    private readonly ITodoDbContext _dbContext;

    public DeleteTodoItemCommandHandler(ITodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Items
            .FindAsync(new object[] {request.Id}, cancellationToken);

        if (entity == null || entity.TodoListId != request.ListId || entity.UserId != request.UserId)
        {
            throw new NotFoundExceptions(nameof(Todo.Domain.TodoItem), request.Id);
        }

        _dbContext.Items.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}