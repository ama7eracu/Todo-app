using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Interfaces;
using TodoApp.Application.TodoItem.Queries.SortTodoItems;

namespace TodoApp.Application.TodoItem.Queries.SortByAlphabetTodoItems;

public class SortTodoItemsQueryHandler:IRequestHandler<SortTodoItemsQuery,SortTodoItemsVm>
{
    private readonly ITodoDbContext _dbContext;
    private readonly IMapper _mapper;
    public SortTodoItemsQueryHandler(ITodoDbContext dbContext,IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }


    public async Task<SortTodoItemsVm> Handle(SortTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var processlist = await _dbContext
            .Items.Where(item => item.TodoListId == 
                request.ListId && item.UserId == request.UserID).AsNoTracking().ToListAsync(cancellationToken);
        
        var sortedlist = processlist.
            Select(item => _mapper.Map<SortTodoItemsDto>(item)).OrderBy(item=>item.Title).ToList();
        
        return new SortTodoItemsVm {SortItems = sortedlist};
        
    }
}