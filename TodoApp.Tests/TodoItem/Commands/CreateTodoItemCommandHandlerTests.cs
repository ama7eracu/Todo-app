using Microsoft.EntityFrameworkCore;
using TodoApp.Application.TodoItem.Commands.CreateTodoItem;
using TodoApp.Tests.Common;
using Xunit;

namespace TodoApp.Tests.TodoItem.Commands;

public class CreateTodoItemCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateTodoItemCommandHandlerTests_Success()
    {
        //Arrange
        var handler = new CreateTodoItemCommandHandler(Context);
        var itemName = "Item Name";
        var itemDescription = "Item Description";
        var listId = Guid.NewGuid();

        //Act
        var todoItemId = await handler.Handle(new CreateTodoItemCommand
        {
            Description = itemDescription,
            Title = itemName,
            ListId = listId,
            UserId = TodoAppContextFactory.UserBId
        }, CancellationToken.None);

        //Assert
        Assert.NotNull(await Context.Items.SingleOrDefaultAsync(item =>
            item.Id == todoItemId && item.Description == itemDescription
                                  && item.TodoListId == listId));
    }
}