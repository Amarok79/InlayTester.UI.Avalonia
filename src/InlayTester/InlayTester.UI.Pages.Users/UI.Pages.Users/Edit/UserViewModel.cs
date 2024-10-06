// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using InlayTester.Domain;
using InlayTester.UI.Shell;


namespace InlayTester.UI.Pages.Users;


[Transient]
[Export<UserEditViewModel>]
[View<UserEditView>]
public partial class UserEditViewModel : PageViewModel
{
    [Import]
    public required IUserManager UserManager { get; set; }

    [Import]
    public required IUserSessionManager UserSessionManager { get; set; }


    public Boolean IsCreateNew => Arg == null;


    protected override void OnInitialize()
    {
        IsBusy = true;

        Shell.IsHomeButtonVisible = false;
        Shell.IsUserStatusItemEnabled = false;

        Shell.PageTitle = Loc["users.page-title"];

        PageHeader = Loc[IsCreateNew ? "users.page-header-new" : "users.page-header-edit"];
        PageIcon = IsCreateNew ? UsersIcons.NewUser : UsersIcons.EditUser;

        CancelLabel = IsCreateNew ? Loc["users.button-cancel-new"] : Loc["users.button-cancel-edit"];
        AcceptLabel = IsCreateNew ? Loc["users.button-accept-new"] : Loc["users.button-accept-edit"];
    }


    protected override async Task OnEnteringAsync()
    {
        try
        {
            if (IsCreateNew)
                _PrepareForNewUser();
            else
                await _PrepareForEditUser();

            IsBusy = false;
        }
        catch (Exception exception)
        {
            IsBusy = false;

            await Shell.MessageBox.ShowErrorAsync("USR100", exception);
            await Shell.Navigation.GoToAsync(UserPages.List, NavigationDirection.Backward);
        }
    }

    private void _PrepareForNewUser()
    {
        MachineOperator = true;

        IsNameEnabled = true;
        IsRolesEnabled = true;
    }

    private async Task _PrepareForEditUser()
    {
        var user = await UserManager.GetUserAsync(Arg!);

        Guard.IsNotNull(user);

        Name = user.Name;
        Password1 = user.Password;
        Password2 = user.Password;
        MachineOperator = user.IsMachineOperator;
        MachineSetter = user.IsMachineSetter;
        Administrator = user.IsAdministrator;
        Notes = user.Notes;

        IsNameEnabled = false;
        IsRolesEnabled = !user.IsSupervisor;
    }


    private Boolean CanCancel()
    {
        return !IsBusy;
    }

    [RelayCommand(CanExecute = nameof(CanCancel))]
    private async Task Cancel()
    {
        await Shell.Navigation.GoToAsync(UserPages.List, NavigationDirection.Backward);
    }


    private Boolean CanAccept()
    {
        return !IsBusy;
    }

    [RelayCommand(CanExecute = nameof(CanAccept))]
    private async Task Accept()
    {
        try
        {
            if (IsCreateNew)
                await _CheckWhetherNameIsUnique();

            ValidateAllProperties();

            if (!HasErrors)
                await _SaveAndReturn();
        }
        catch (Exception exception)
        {
            IsBusy = false;

            await Shell.MessageBox.ShowErrorAsync("USR101", exception);
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task _CheckWhetherNameIsUnique()
    {
        if (Name.IsNullOrWhitespace())
            HasUniqueName = true;
        else
        {
            var contains = await UserManager.ContainsUserNameAsync(Name ?? String.Empty);

            HasUniqueName = !contains;
        }
    }

    private async Task _SaveAndReturn()
    {
        IsBusy = true;

        if (IsCreateNew)
            await _SaveNewUser();
        else
            await _SaveExistingUser();

        await Shell.Navigation.GoToAsync(UserPages.List, NavigationDirection.Backward);
    }

    private async Task _SaveNewUser()
    {
        var user = this.ToModel(UserSessionManager.GetCurrentUserName() ?? String.Empty);

        await UserManager.AddUserAsync(user);
    }

    private async Task _SaveExistingUser()
    {
        var user = this.ToModel(UserSessionManager.GetCurrentUserName() ?? String.Empty);

        var existing = await UserManager.GetUserAsync(Arg!);

        existing = existing! with {
            Password = user.Password,
            Roles = user.Roles,
            Notes = user.Notes,
            ModifiedBy = user.ModifiedBy,
            ModifiedOn = user.ModifiedOn,
        };

        await UserManager.UpdateUserAsync(existing);
    }


    partial void OnNameChanged(String? value)
    {
        HasUniqueName = true;
    }

    partial void OnPassword1Changed(String? value)
    {
        ValidateProperty(Password2, nameof(Password2));
    }

    partial void OnMachineOperatorChanged(Boolean value)
    {
        ValidateProperty(Roles, nameof(Roles));
    }

    partial void OnMachineSetterChanged(Boolean value)
    {
        ValidateProperty(Roles, nameof(Roles));
    }

    partial void OnAdministratorChanged(Boolean value)
    {
        ValidateProperty(Roles, nameof(Roles));
    }


    protected override void OnIsBusyChanged()
    {
        base.OnIsBusyChanged();

        AcceptCommand.NotifyCanExecuteChanged();
        CancelCommand.NotifyCanExecuteChanged();
    }
}
