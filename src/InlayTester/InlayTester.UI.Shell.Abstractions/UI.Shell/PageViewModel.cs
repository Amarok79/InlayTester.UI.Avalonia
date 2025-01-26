// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using Microsoft.Extensions.Localization;


namespace InlayTester.UI.Shell;


public abstract class PageViewModel : ViewModelWithBusyProgress,
    INavigationAware
{
    [Import]
    public required IShell Shell { get; set; }

    [Import]
    public required IStringLocalizer Loc { get; set; }


    public String? Arg { get; private set; }


    protected virtual void OnInitialize()
    {
    }

    protected virtual Task OnEnteringAsync()
    {
        return Task.CompletedTask;
    }

    protected virtual Task OnLeavingAsync()
    {
        return Task.CompletedTask;
    }


    public Task InitializeAsync(String? arg)
    {
        Arg = arg;

        Shell.IsHomeButtonVisible     = false;
        Shell.IsUserStatusItemEnabled = false;

        OnInitialize();

        return Task.CompletedTask;
    }

    public Task EnterAsync()
    {
        return OnEnteringAsync();
    }

    public Task LeaveAsync()
    {
        return OnLeavingAsync();
    }
}
