// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using InlayTester.UI.Shell.Infrastructure;
using Microsoft.Extensions.Logging;


namespace InlayTester.UI.Shell;


[Export<IOverlayManager>]
[Export<OverlayViewModel>]
[View<Overlay>]
public partial class OverlayViewModel : ObservableObject,
    IOverlayManager
{
    [Import]
    public required ILayerManager LayerManager { get; set; }

    [Import]
    public required IViewFactory ViewFactory { get; set; }

    [Import]
    public required ILogger<OverlayViewModel> Logger { get; set; }


    public Task<Object?> ShowAsync<TViewModel>(CancellationToken cancellationToken = default)
        where TViewModel : class
    {
        var viewModel = ViewFactory.CreateViewModel<TViewModel>();

        return ShowAsync(viewModel, cancellationToken);
    }

    public Task<Object?> ShowAsync(String viewModelContractKey, CancellationToken cancellationToken = default)
    {
        var viewModel = ViewFactory.CreateViewModel(viewModelContractKey);

        return ShowAsync(viewModel, cancellationToken);
    }

    public async Task<Object?> ShowAsync(Object viewModel, CancellationToken cancellationToken = default)
    {
        var ctx = new OverlayContext();

        if (viewModel is IOverlayAware overlayAware)
        {
            overlayAware.Context = ctx;
        }


        CancellationTokenRegistration registration = default;

        if (cancellationToken.CanBeCanceled)
        {
            registration = cancellationToken.Register(() => ctx.Close());
        }


        LayerManager.ShowOverlay();

        Content = viewModel;
        IsOpen  = true;

        Logger.LogInformation("Opened {ViewModel} overlay", viewModel.GetType().Name);


        var result = await ctx.TaskCompletionSource.Task;

        await registration.DisposeAsync();


        IsOpen  = false;
        Content = null;

        LayerManager.HideOverlay();

        Logger.LogInformation(
            "Closed {ViewModel} overlay -> Result: {Result}",
            viewModel.GetType().Name,
            result
        );


        return result;
    }
}
