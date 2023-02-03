using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.TodoItem.Commands.DeleteCommand;
using TodoApp.Tests.Common;

namespace TodoApp.Tests.TodoItem;

public class DeleteTodoItemCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteTodoItemCommandHandler_Success()
    {
        //Arrange
        var handler = new DeleteTodoItemCommandHandler(Context);

        //Act
        await handler.Handle(new DeleteTodoItemCommand
        {
            Id = TodoAppContextFactory.TodoItemForDelete,
            ListId = TodoAppContextFactory.TodoListForDelete,
            UserId = TodoAppContextFactory.UserAId
        }, CancellationToken.None);

        //Assert
        Assert.Null(await Context.Items.SingleOrDefaultAsync(item =>
            item.Id == TodoAppContextFactory.TodoItemForDelete));
    }

    [Fact]
    public async Task DeleteTodoItemCommandHandler_WrongOnId()
    {
        //Arrange
        var handler = new DeleteTodoItemCommandHandler(Context);

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
            await handler.Handle(new DeleteTodoItemCommand
            {
                Id = Guid.NewGuid(),
                ListId = TodoAppContextFactory.TodoListForDelete,
                UserId = TodoAppContextFactory.UserAId
            }, CancellationToken.None));
    }
}