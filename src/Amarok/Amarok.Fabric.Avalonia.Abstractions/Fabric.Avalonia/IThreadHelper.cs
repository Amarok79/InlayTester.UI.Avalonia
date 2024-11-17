// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Microsoft.VisualStudio.Threading;


namespace Amarok.Fabric.Avalonia;


/// <summary>
///     A service for switching between the main thread and background threads.
/// </summary>
public interface IThreadHelper
{
    /// <summary>
    ///     Checks whether the current thread is the main thread.
    /// </summary>
    Boolean CheckAccess();

    /// <summary>
    ///     Checks whether the current thread is the main thread and throws if not.
    /// </summary>
    void VerifyAccess();


    /// <summary>
    ///     Switches to the main thread.
    /// </summary>
    JoinableTaskFactory.MainThreadAwaitable SwitchToMainThreadAsync();

    /// <summary>
    ///     Switches to a background thread.
    /// </summary>
    TaskScheduler SwitchToBackgroundThreadAsync();


    /// <summary>
    ///     Runs the specified asynchronous method to completion while synchronously blocking the calling thread.
    /// </summary>
    void Run(Func<Task> asyncAction);

    /// <summary>
    ///     Runs the specified asynchronous method to completion while synchronously blocking the calling thread.
    /// </summary>
    T Run<T>(Func<Task<T>> asyncFunc);


    /// <summary>
    ///     Runs the specified asynchronous method to completion without blocking the calling thread.
    /// </summary>
    JoinableTask RunAsync(Func<Task> asyncAction);

    /// <summary>
    ///     Runs the specified asynchronous method to completion without blocking the calling thread.
    /// </summary>
    JoinableTask<T> RunAsync<T>(Func<Task<T>> asyncFunc);
}
