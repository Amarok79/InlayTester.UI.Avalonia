// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


internal sealed class OverlayContext : IOverlayContext
{
    public TaskCompletionSource<Object?> TaskCompletionSource { get; } = new();


    public void Close(Object? result = null)
    {
        TaskCompletionSource.TrySetResult(result);
    }
}
