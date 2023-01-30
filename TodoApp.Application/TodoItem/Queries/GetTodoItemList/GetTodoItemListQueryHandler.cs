using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.TodoItem.Queries.GetTodoItemList;

public class GetTodoItemListQueryHandler:IRequestHandler<GetTodoItemListQuery,TodoItemVm>
{
    private readonly ITodoDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetTodoItemListQueryHandler(ITodoDbContext dbContext,IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<TodoItemVm> Handle(GetTodoItemListQuery request, CancellationToken cancellationToken)
    {
        var listItems = await _dbContext
            .Items.Where(item => item.TodoListId == request.ListId).ToListAsync(cancellationToken);

        var listItemsDto =  listItems
            .Select(item => _mapper.Map<TodoItemLookUpDto>(item)).ToList();

        return new TodoItemVm {Items = listItemsDto};
    }
}