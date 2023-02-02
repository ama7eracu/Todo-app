using TodoApp.Persistence;

namespace TodoApp.Tests.Common;

public abstract class TestCommandBase: IDisposable
{
    protected  readonly TodoDbContext Context;

    protected TestCommandBase()
    {
        Context = TodoAppContextFactory.Create();
    }
    public void Dispose()
    {
        TodoAppContextFactory.Destroy(Context);
    }
}