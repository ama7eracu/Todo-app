using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.TodoList.Commands.UpdateTodoList;
using TodoApp.Tests.Common;
using Xunit;

namespace TodoApp.Tests.TodoList.Commands;

public class UpdateTodoListCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateTodoListCommandHandler_Success()
    {
        //Arrange
        var handler = new UpdateTodoListCommandHandler(Context);
        var updatedTitle = "new Title";
        var updatedDescription = "new Description";
        //Act
        await handler.Handle(new UpdateTodoListCommand
            {
                Title = updatedTitle,
                Description = updatedDescription,
                UserId = TodoAppContextFactory.UserAId,
                Id = TodoAppContextFactory.TodoListForUpdate
            },
            CancellationToken.None);

        //Assert
        Assert.NotNull(await Context.TodoLists.SingleOrDefaultAsync(list =>
            list.Id == TodoAppContextFactory.TodoListForUpdate && list.Title == updatedTitle
                                                               && list.Description == updatedDescription));
    }

    [Fact]
    public async Task UpdateTodoListCommandHandler_WrongOnId()
    {
        //Arrange
        var handler = new UpdateTodoListCommandHandler(Context);

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
            await handler.Handle(new UpdateTodoListCommand
            {
                Id = Guid.NewGuid(),
                UserId = TodoAppContextFactory.UserBId
            }, CancellationToken.None));
    }

    [Fact]
    public async Task UpdateTodoListCommandHandler_WrongUserId()
    {
        //Arrange
        var handler = new UpdateTodoListCommandHandler(Context);

        //Act
        //Assert
        await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
            await handler.Handle(new UpdateTodoListCommand
            {
                UserId = TodoAppContextFactory.UserBId,
                Id = TodoAppContextFactory.TodoListForUpdate
            }, CancellationToken.None));
    }
}