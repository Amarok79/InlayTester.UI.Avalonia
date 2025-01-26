// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.Input;
using InlayTester.UI.Shell.Infrastructure;


namespace InlayTester.UI.Shell;


[Export<IShell>]
[Export<INavigationHost>]
[Export<ILayerManager>]
[Export<ShellViewModel>]
[View<ShellView>]
public partial class ShellViewModel : ViewModelWithLogger,
    IShell,
    INavigationHost,
    ILayerManager
{
    private Boolean mIsOverlayVisible;
    private Boolean mIsMessageBoxVisible;


    [Import]
    public required INavigationService Navigation { get; set; }

    [Import]
    public required Lazy<IOverlayManager> OverlayManager { get; set; }

    public IOverlayManager Overlay => OverlayManager.Value;

    [Import]
    public required Lazy<IMessageBoxManager> MessageBoxManager { get; set; }

    public IMessageBoxManager MessageBox => MessageBoxManager.Value;


    [RelayCommand]
    public async Task QuitApplication()
    {
        await Navigation.GoToAsync("", NavigationDirection.Backward);

        IsBaseLayerEnabled       = false;
        IsMessageBoxLayerEnabled = false;
        IsOverlayLayerEnabled    = false;

        await Task.Delay(500);

        Dispatcher.UIThread.BeginInvokeShutdown(DispatcherPriority.Default);
    }


    public void ShowOverlay()
    {
        mIsOverlayVisible = true;

        IsBaseLayerEnabled       = false;
        IsOverlayLayerEnabled    = true;
        IsMessageBoxLayerEnabled = mIsMessageBoxVisible;
    }

    public void HideOverlay()
    {
        mIsOverlayVisible = false;

        IsBaseLayerEnabled       = true;
        IsOverlayLayerEnabled    = false;
        IsMessageBoxLayerEnabled = mIsMessageBoxVisible;
    }

    public void ShowMessageBox()
    {
        mIsMessageBoxVisible = true;

        IsBaseLayerEnabled       = false;
        IsOverlayLayerEnabled    = false;
        IsMessageBoxLayerEnabled = true;
    }

    public void HideMessageBox()
    {
        mIsMessageBoxVisible = false;

        IsBaseLayerEnabled       = !mIsOverlayVisible;
        IsOverlayLayerEnabled    = mIsOverlayVisible;
        IsMessageBoxLayerEnabled = false;
    }
}
