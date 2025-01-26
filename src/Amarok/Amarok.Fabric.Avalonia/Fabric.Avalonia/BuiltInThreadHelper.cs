// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using CommunityToolkit.Diagnostics;
using Microsoft.VisualStudio.Threading;


namespace Amarok.Fabric.Avalonia;


[Export<IThreadHelper>]
internal sealed class BuiltInThreadHelper : IThreadHelper
{
    public JoinableTaskContext Context { get; } = new();


    public Boolean CheckAccess()
    {
        return Context.IsOnMainThread;
    }

    public void VerifyAccess()
    {
        if (!Context.IsOnMainThread)
        {
            ThrowHelper.ThrowInvalidOperationException("Not on the main thread");
        }
    }


    public JoinableTaskFactory.MainThreadAwaitable SwitchToMainThreadAsync()
    {
        return Context.Factory.SwitchToMainThreadAsync();
    }

    public TaskScheduler SwitchToBackgroundThreadAsync()
    {
        return TaskScheduler.Default;
    }


    public void Run(Func<Task> asyncAction)
    {
        Context.Factory.Run(asyncAction);
    }

    public T Run<T>(Func<Task<T>> asyncFunc)
    {
        return Context.Factory.Run(asyncFunc);
    }


    public JoinableTask RunAsync(Func<Task> asyncAction)
    {
        return Context.Factory.RunAsync(asyncAction);
    }

    public JoinableTask<T> RunAsync<T>(Func<Task<T>> asyncFunc)
    {
        return Context.Factory.RunAsync(asyncFunc);
    }
}
