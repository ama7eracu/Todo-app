using AutoMapper;
using Todo.Domain;
using TodoApp.Application.TodoList.Commands.CreateTodoList;

namespace Todo.WebApi.Models;

public class CreateTodoListDto
{
    public string Description { get; set; }
    public string Title { get; set; }
}