using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.TodoItem.Commands.UpdateTodoItem;

public class UpdateTodoItemHandler:IRequestHandler<UpdateTodoItemCommand>
{
    private readonly ITodoDbContext _dbContext;

    public UpdateTodoItemHandler(ITodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Items
            .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken);

        if (item == null || item.ListID != request.ListId)
        {
            throw new NotFoundExceptions(nameof(Todo.Domain.TodoItem), item.Id);
        }

        item.Description = request.Description;
        item.Title = request.Title;
        item.Done = request.Done;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;


    }
}