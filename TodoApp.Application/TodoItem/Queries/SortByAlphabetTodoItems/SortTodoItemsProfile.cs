using AutoMapper;

namespace TodoApp.Application.TodoItem.Queries.SortTodoItems;

public class SortTodoItemsProfile : Profile
{
    public SortTodoItemsProfile()
    {
        CreateMap<SortTodoItemsDto, Todo.Domain.TodoItem>().ReverseMap();
    }
}