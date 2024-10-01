// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using InlayTester.Domain;
using InlayTester.UI.Shell;


namespace InlayTester.UI.Pages.Users;


[Transient]
[ExportViewModel(UserOverlays.Login)]
[View<LoginOverlay>]
public partial class LoginOverlayViewModel : ViewModelWithBusy,
    IOverlayAware
{
    [Import]
    public required IUserManager UserManager { get; set; }

    [Import]
    public required IUserSessionManager UserSessionManager { get; set; }

    [Import]
    public required IShell Shell { get; set; }


    public IOverlayContext? Context { get; set; }


    protected override async Task OnActivatedAsync()
    {
        await base.OnActivatedAsync();

        try
        {
            IsBusy = true;

            var users = await UserManager.QueryUsersAsync();

            Users.AddRange(users.OrderBy(x => x.Name));

            IsBusy = false;
        }
        catch (Exception exception)
        {
            IsBusy = false;

            await Shell.MessageBox.ShowErrorAsync("USR300", exception);

            Context?.Close(false);
        }
    }


    [RelayCommand]
    private void Cancel()
    {
        Context?.Close(false);
    }


    [RelayCommand]
    private async Task Login()
    {
        UserToValidate = null;

        ValidateAllProperties();

        if (!HasErrors)
        {
            try
            {
                IsBusy = true;

                var user = await UserManager.GetUserAsync(SelectedUser!.Id);

                Guard.IsNotNull(user);

                UserToValidate = user;

                ValidateAllProperties();

                if (!HasErrors)
                {
                    UserSessionManager.Login(user);

                    Context?.Close(true);
                }
            }
            catch (Exception exception)
            {
                await Shell.MessageBox.ShowErrorAsync("USR301", exception);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
