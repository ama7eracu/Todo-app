using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.TodoList.Commands.UpdateTodoList;

public class UpdateTodoListCommandHandler
    : IRequestHandler<UpdateTodoListCommand>
{
    private readonly ITodoDbContext _dbContext;

    public UpdateTodoListCommandHandler(ITodoDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateTodoListCommand request,
        CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.TodoLists.FirstOrDefaultAsync(list =>
                list.Id == request.Id, cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundExceptions(nameof(Todo.Domain.TodoList), request.Id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}