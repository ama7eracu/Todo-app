using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.TodoItem.Commands.CreateTodoItem;
using TodoApp.Application.TodoItem.Commands.DeleteCommand;
using TodoApp.Tests.Common;
using Xunit;

namespace TodoApp.Tests.TodoItem.Commands;

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
                ListId = Guid.Parse("29A34F36-470B-4471-A6EA-1E5BF50093DE"),
                UserId = TodoAppContextFactory.UserAId
            }, CancellationToken.None));
    }

    [Fact]
    public async Task DeleteTodoItemCommandHandler_WrongOnUserId()
    {
        //Arrange
        var deleteHandler = new DeleteTodoItemCommandHandler(Context);
        var createHandler = new CreateTodoItemCommandHandler(Context);

        //Act
        var itemId = await createHandler.Handle(new CreateTodoItemCommand
        {
            Description = "Fake D",
            ListId = Guid.Parse("E929D6FF-45A0-4279-BE0E-6548DAD67A77"),
            Title = "Fake T",
            UserId = TodoAppContextFactory.UserAId
        }, CancellationToken.None);

        //Assert
      await  Assert.ThrowsAsync<NotFoundExceptions>(async () =>
           await deleteHandler.Handle(new DeleteTodoItemCommand
            {
                Id = itemId,
                ListId = Guid.Parse("E929D6FF-45A0-4279-BE0E-6548DAD67A77"),
                UserId = TodoAppContextFactory.UserBId
            }, CancellationToken.None));
    }
}