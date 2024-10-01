// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using System.Reactive.Disposables;
using Amarok.Fabric.Avalonia;


namespace InlayTester.UI;


/// <summary>
///     A view model base class with additional activation/deactivation support.
/// </summary>
public abstract class ViewModelWithActivation : ViewModelWithThreading,
    IActivationAware,
    IDisposable
{
    private readonly CompositeDisposable mDisposables = new();


    /// <summary>
    ///     Indicates that deactivation (unloading) started.
    /// </summary>
    public Boolean IsDeactivating { get; private set; }

    /// <summary>
    ///     A collection of disposables that get disposed when the View and its corresponding View Model
    ///     are deactivated (unloaded).
    /// </summary>
    public ICollection<IDisposable> Disposables => mDisposables;


    /// <summary>
    ///     Called when the View and its corresponding View Model are activated (loaded).
    /// </summary>
    protected virtual Task OnActivatedAsync()
    {
        return Task.CompletedTask;
    }

    /// <summary>
    ///     Called when the View and its corresponding View Model are deactivated (unloaded).
    /// </summary>
    protected virtual Task OnDeactivatedAsync()
    {
        return Task.CompletedTask;
    }


    public Task ActivatedAsync()
    {
        IsDeactivating = false;

        return OnActivatedAsync();
    }

    public async Task DeactivatedAsync()
    {
        try
        {
            IsDeactivating = true;

            await OnDeactivatedAsync();
        }
        finally
        {
            // clean up resources
            mDisposables.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    protected virtual void Dispose(Boolean disposing)
    {
        if (disposing)
            mDisposables.Dispose();
    }
}
