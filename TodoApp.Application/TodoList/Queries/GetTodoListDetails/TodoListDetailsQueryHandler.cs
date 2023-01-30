using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.Interfaces;
namespace TodoApp.Application.TodoList.Queries.GetTodoListDetails;
using Todo.Domain;
public class TodoListDetailsQueryHandler
    : IRequestHandler<GetTodoListDetailsQuery, TodoListDetailsDto>
{
    private readonly ITodoDbContext _dbContext;
    private readonly IMapper _mapper;

    public TodoListDetailsQueryHandler(ITodoDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TodoListDetailsDto> Handle(GetTodoListDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.TodoLists
            .FirstOrDefaultAsync(list =>
                list.Id == request.Id,cancellationToken);

        if (entity == null || entity.UserId != request.UserId)
        {
            throw new NotFoundExceptions(nameof(TodoList), request.Id);
        }

        return _mapper.Map<TodoListDetailsDto>(entity);
    }
}