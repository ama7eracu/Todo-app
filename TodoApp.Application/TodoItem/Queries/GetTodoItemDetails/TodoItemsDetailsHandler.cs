using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Interfaces;


namespace TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;

using Todo.Domain;

public class TodoItemsDetailsHandler : IRequestHandler<GetTodoItemDetailsQuery, TodoItemsDetailsDto>
{
    private readonly ITodoDbContext _dbContext;
    private readonly IMapper _mapper;

    public TodoItemsDetailsHandler(ITodoDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TodoItemsDetailsDto> Handle(GetTodoItemDetailsQuery request, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Items
            .FirstOrDefaultAsync(entity => entity.Id == request.Id, cancellationToken);

        if (item == null || item.TodoListId != request.ListId || item.UserId != request.UserId)
        {
            throw new NotFoundExceptions(nameof(TodoItem), item.Id);
        }

        return _mapper.Map<TodoItemsDetailsDto>(item);
    }
}