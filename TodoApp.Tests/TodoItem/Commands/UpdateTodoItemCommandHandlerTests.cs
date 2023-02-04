using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.TodoItem.Commands.UpdateTodoItem;
using TodoApp.Tests.Common;
using Xunit;

namespace TodoApp.Tests.TodoItem.Commands;

public class UpdateTodoItemCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateTodoItemCommandHandler_Success()
    {
        //Arrange
        var handler = new UpdateTodoItemCommandHandler(Context);
        var updateTitle = "Update Title";
        var updateDescription = "Update Description";

        //Act
        await handler.Handle(new UpdateTodoItemCommand
        {
            Description = updateDescription,
            Title = updateTitle,
            Done = false,
            Id = TodoAppContextFactory.TodoItemForUpdate,
            ListId = TodoAppContextFactory.TodoListForUpdate,
            UserId = TodoAppContextFactory.UserAId
        }, CancellationToken.None);

        //Assert
        Assert.NotNull(async () =>
            await Context.Items.SingleOrDefaultAsync(item =>
                item.Id == TodoAppContextFactory.TodoItemForUpdate && item.Title == updateTitle
                                                                   && item.Description == updateDescription));
    }

    [Fact]
    public async Task UpdateTodoItemCommandHandler_WrongOnId()
    {
        //Arrange
        var handler = new UpdateTodoItemCommandHandler(Context);

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundExceptions>(async () => 
            await handler.Handle(new UpdateTodoItemCommand
        {
            Id = Guid.NewGuid(),
            ListId = TodoAppContextFactory.TodoListForUpdate,
            UserId = TodoAppContextFactory.UserAId
        }, CancellationToken.None));
    }

    [Fact]
    public async Task UpdateTodoItemCommandHandler_WrongOnUserID()
    {
        //Arrange
        var handler = new UpdateTodoItemCommandHandler(Context);

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
            await handler.Handle(new UpdateTodoItemCommand
            {
                Id = TodoAppContextFactory.TodoItemForUpdate,
                ListId = TodoAppContextFactory.TodoListForUpdate,
                UserId = TodoAppContextFactory.UserBId
            }, CancellationToken.None));
    }
}