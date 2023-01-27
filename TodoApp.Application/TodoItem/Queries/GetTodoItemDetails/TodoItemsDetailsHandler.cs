using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Interfaces;
using TodoApp.Application.TodoList.Queries.GetTodoListDetails;

namespace TodoApp.Application.TodoItem.Queries.GetTodoItemDetails;

public class TodoItemsDetailsHandler:IRequestHandler<GetTodoItemDetailsQuery,TodoItemsDetailsDto>
{
    private readonly ITodoDbContext _dbContext;
    private readonly IMapper _mapper;

    public TodoItemsDetailsHandler(ITodoDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<TodoItemsDetailsDto> Handle(GetTodoItemDetailsQuery request, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Items
            .FirstOrDefaultAsync(entity => entity.Id == request.Id,cancellationToken);

        if (item == null || item.Id != request.ListId)
        {
            throw new NotFoundExceptions(nameof(Todo.Domain.TodoItem), item.Id);
        }

        return _mapper.Map<TodoItemsDetailsDto>(item);
    }
}