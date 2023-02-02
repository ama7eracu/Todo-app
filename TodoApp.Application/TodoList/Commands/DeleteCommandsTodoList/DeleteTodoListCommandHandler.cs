using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.TodoList.Commands.DeleteCommandsTodoList;

public class DeleteTodoListCommandHandler
    : IRequestHandler<DeleteTodoListCommand>
{
    private readonly ITodoDbContext _dbContext;

    public DeleteTodoListCommandHandler(ITodoDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteTodoListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.TodoLists
            .FindAsync(new object[] {request.Id}, cancellationToken);
        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundExceptions(nameof(Todo.Domain.TodoList), request.Id);
        }

        _dbContext.TodoLists.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}