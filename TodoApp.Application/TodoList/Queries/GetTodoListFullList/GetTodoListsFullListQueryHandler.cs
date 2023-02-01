using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.TodoList.Queries.GetTodoListFullList;

public class GetTodoListsFullListHandler:IRequestHandler<GetTodoListsFullListQuery,TodoListVm>
{
    private readonly ITodoDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTodoListsFullListHandler(ITodoDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }
    
    public async Task<TodoListVm> Handle(GetTodoListsFullListQuery request, CancellationToken cancellationToken)
    {
        var  TodoListsQuery = await _dbContext.TodoLists
            .Where(list => list.UserId == request.UserId).AsNoTracking().ToListAsync(cancellationToken);
        var TodoListsQueryDto =
            TodoListsQuery.Select(list => _mapper.Map<TodoListLookUpDto>(list)).ToList();
        
        return new TodoListVm {TodoLists = TodoListsQueryDto};

    }
}