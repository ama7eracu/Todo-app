using Microsoft.EntityFrameworkCore;
using TodoApp.Application.Common.Exceptions;
using TodoApp.Application.TodoList.Commands.CreateTodoList;
using TodoApp.Application.TodoList.Commands.DeleteCommandsTodoList;
using TodoApp.Tests.Common;

namespace TodoApp.Tests.TodoList.Commands
{
    public class DeleteTodoListCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteTodoListCommandHandler_Success()
        {
            //Arrange
            var handler = new DeleteTodoListCommandHandler(Context);

            //Act
            await handler.Handle(new DeleteTodoListCommand
            {
                Id = TodoAppContextFactory.TodoListForDelete,
                UserId = TodoAppContextFactory.UserAId
            }, CancellationToken.None);

            //Assert
            Assert.Null(await Context.TodoLists.SingleOrDefaultAsync(list =>
                list.Id == TodoAppContextFactory.TodoListForDelete));
        }

        [Fact]
        public async Task DeleteTodoListCommandHandler_FailOnWrongId()
        {
            //Arrange
            var handler = new DeleteTodoListCommandHandler(Context);

            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
                await handler.Handle(
                    new DeleteTodoListCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = TodoAppContextFactory.UserAId
                    }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteTodoListCommandHandler_FailOnWrongUserId()
        {
            //Arrange
            var deleteHandler = new DeleteTodoListCommandHandler(Context);
            var createHandler = new CreateTodoListCommandHandler(Context);

            //Act
            var listId = await createHandler.Handle(new CreateTodoListCommand
                {
                    Title = "Fake Title",
                    Description = "Fake Description",
                    UserId = TodoAppContextFactory.UserAId
                },
                CancellationToken.None);
            //Assert
            await Assert.ThrowsAsync<NotFoundExceptions>(async () =>
                await deleteHandler.Handle(new DeleteTodoListCommand
                    {
                        Id = listId,
                        UserId = TodoAppContextFactory.UserBId
                    },
                    CancellationToken.None));
        }
    }
}