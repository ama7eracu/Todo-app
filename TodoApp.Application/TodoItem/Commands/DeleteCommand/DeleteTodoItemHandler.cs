using MediatR;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.TodoItem.Commands.DeleteCommand;

public class DeleteTodoItemHandler:IRequestHandler<DeleteTodoItemCommand>
{
    private readonly ITodoDbContext _dbContext;

    public DeleteTodoItemHandler(ITodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Items
            .FindAsync(new object[] {request.Id}, cancellationToken);
        
        if (item == null || item.TodoListId != request.ListId || item.UserId!=request.UserId)
        {
            throw new NotFoundExceptions(nameof(Todo.Domain.TodoItem), item.Id);
        }

        _dbContext.Items.Remove(item);
        _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}