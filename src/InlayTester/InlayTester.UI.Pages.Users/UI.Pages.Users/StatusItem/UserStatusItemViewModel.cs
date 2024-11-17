// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using CommunityToolkit.Mvvm.Input;
using InlayTester.Domain;
using InlayTester.UI.Shell;
using Material.Icons;
using Microsoft.Extensions.Localization;


namespace InlayTester.UI.Pages.Users;


[Transient]
[ExportViewModel("USER/STATUS-ITEM")]
[View<UserStatusItem>]
public partial class UserStatusItemViewModel : ViewModelWithActivation
{
    [Import]
    public required IShell Shell { get; set; }

    [Import]
    public required IUserSessionManager UserSessionManager { get; set; }

    [Import]
    public required IStringLocalizer Loc { get; set; }


    protected override async Task OnActivatedAsync()
    {
        await base.OnActivatedAsync();

        _Refresh();

        Disposables.Add(UserSessionManager.CurrentChanged.Subscribe(_ => _Refresh()));
    }


    private void _Refresh()
    {
        var current = UserSessionManager.Current;

        if (current == null)
        {
            IsLoggedIn = false;
            Icon       = MaterialIconKind.Login;
            Text       = Loc["shell.button-login"];
            ToolTip    = Loc["shell.tooltip-logged-out"];
        }
        else
        {
            IsLoggedIn = true;
            Icon       = MaterialIconKind.User;
            Text       = current.Name;
            ToolTip    = Loc["shell.tooltip-logged-in", current.Name];
        }
    }


    [RelayCommand]
    public async Task Login()
    {
        if (!IsLoggedIn)
            await Shell.ShowLoginAsync();
    }

    [RelayCommand]
    public Task Logout()
    {
        UserSessionManager.Logout();

        return Task.CompletedTask;
    }

    [RelayCommand]
    public async Task SwitchUser()
    {
        await Shell.ShowLoginAsync();
    }
}
