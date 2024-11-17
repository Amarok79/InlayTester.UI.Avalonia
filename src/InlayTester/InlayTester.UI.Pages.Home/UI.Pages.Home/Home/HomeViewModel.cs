// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using CommunityToolkit.Mvvm.Input;
using InlayTester.Domain;
using InlayTester.UI.Pages.Users;
using InlayTester.UI.Shell;


namespace InlayTester.UI.Pages.Home.Home;


[Transient]
[Export<HomeViewModel>]
[View<HomeView>]
public partial class HomeViewModel : PageViewModel
{
    [Import]
    public required IUserSessionManager UserSessionManager { get; set; }


    protected override void OnInitialize()
    {
        Shell.IsUserStatusItemEnabled = true;
        Shell.IsHomeButtonVisible     = false;

        Shell.PageTitle = Loc["home.page-title"];
    }


    protected override async Task OnEnteringAsync()
    {
        _UpdateCurrentUser();

        Disposables.Add(UserSessionManager.CurrentChanged.Subscribe(_UpdateCurrentUser));

        if (CurrentUser == null)
        {
            await Task.Delay(250);
            await Shell.ShowLoginAsync();
        }

        IsBusy = false;
    }


    private void _UpdateCurrentUser()
    {
        CurrentUser = UserSessionManager.Current;
    }


    private Boolean CanRunTest()
    {
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanRunTest))]
    private Task RunTest()
    {
        return Task.CompletedTask;
    }


    private Boolean CanManageSubstrates()
    {
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanManageSubstrates))]
    private Task ManageSubstrates()
    {
        return Task.CompletedTask;
    }


    private Boolean CanManageChips()
    {
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanManageChips))]
    private Task ManageChips()
    {
        return Task.CompletedTask;
    }


    private Boolean CanManageDistances()
    {
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanManageDistances))]
    private Task ManageDistances()
    {
        return Task.CompletedTask;
    }


    private Boolean CanManageDriveWheel()
    {
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanManageDriveWheel))]
    private Task ManageDriveWheel()
    {
        return Task.CompletedTask;
    }


    private Boolean CanAdministerUsers()
    {
        return CurrentUser?.IsAdministrator ?? false;
    }

    [RelayCommand(CanExecute = nameof(CanAdministerUsers))]
    private async Task AdministerUsers()
    {
        await Shell.Navigation.GoToAsync(UserPages.List, NavigationDirection.Forward);
    }


    private Boolean CanAdministerSettings()
    {
        return false;
    }

    [RelayCommand(CanExecute = nameof(CanAdministerSettings))]
    private Task AdministerSettings()
    {
        return Task.CompletedTask;
    }
}
