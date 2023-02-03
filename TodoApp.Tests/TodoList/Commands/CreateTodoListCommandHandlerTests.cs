using Microsoft.EntityFrameworkCore;
using TodoApp.Application.TodoList.Commands.CreateTodoList;
using TodoApp.Tests.Common;

namespace TodoApp.Tests.TodoList.Commands;

public class CreateTodoListCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateTodoListHandler_Success()
    {
        //Arrange
        var handler = new CreateTodoListCommandHandler(Context);
        var todoListName = "todoList name";
        var todoListDescription = "todoList Description";

        //Act
        var todoListId = await handler.Handle(
            new CreateTodoListCommand
            {
                Description = todoListDescription,
                Title = todoListName,
                UserId = TodoAppContextFactory.UserAId,
            },
            CancellationToken.None);

        //Assert
        Assert.NotNull(
            await Context.TodoLists.SingleOrDefaultAsync(list =>
                list.Id == todoListId && list.Title == todoListName &&
                list.Description == todoListDescription));
    }
}