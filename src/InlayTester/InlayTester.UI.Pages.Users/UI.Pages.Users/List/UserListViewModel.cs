// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Reactive.Linq;
using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using DynamicData.Binding;
using InlayTester.Domain;
using InlayTester.UI.Pages.Home;
using InlayTester.UI.Shell;


namespace InlayTester.UI.Pages.Users;


[Transient]
[Export<UserListViewModel>]
[View<UserListView>]
public partial class UserListViewModel : PageViewModel
{
    [Import]
    public required IUserManager UserManager { get; set; }


    public UserListViewModel()
    {
        mUsersSource.Connect()
            .Filter(
                this.WhenValueChanged(x => x.SearchText)
                    .Throttle(TimeSpan.FromMilliseconds(100))
                    .Select(filterFunc)
            )
            .Sort(SortExpressionComparer<UserListItemViewModel>.Ascending(x => x.Name ?? String.Empty))
            .Bind(out _Users)
            .Subscribe();

        static Func<UserListItemViewModel, Boolean> filterFunc(String? searchText)
        {
            return x => x.User.Filter(searchText);
        }
    }


    protected override void OnInitialize()
    {
        IsBusy = true;

        Shell.IsHomeButtonVisible = true;
        Shell.IsUserStatusItemEnabled = false;

        Shell.PageTitle = Loc["users.page-title"];

        PageHeader = Loc["users.page-header-list"];
        PageIcon = UsersIcons.ListUsers;
    }


    protected override async Task OnEnteringAsync()
    {
        try
        {
            await _LoadUsers();

            IsBusy = false;
        }
        catch (Exception exception)
        {
            IsBusy = false;

            await Shell.MessageBox.ShowErrorAsync("USR200", exception);
            await Shell.Navigation.GoToAsync(HomePages.Home, NavigationDirection.Backward);
        }
    }

    private async Task _LoadUsers()
    {
        var users = await UserManager.QueryUsersAsync();

        mUsersSource.Clear();
        mUsersSource.AddRange(users.Select(x => x.ToViewModel(this, Loc)));
    }


    protected override void Dispose(Boolean disposing)
    {
        base.Dispose(disposing);

        mUsersSource.Dispose();
    }


    private Boolean CanCreate()
    {
        return !IsBusy;
    }

    [RelayCommand(CanExecute = nameof(CanCreate))]
    private async Task Create()
    {
        await Shell.Navigation.GoToAsync(UserPages.Edit, NavigationDirection.Forward);
    }


    private Boolean CanEdit()
    {
        return !IsBusy;
    }

    [RelayCommand(CanExecute = nameof(CanEdit))]
    private async Task Edit(UserListItemViewModel item)
    {
        if (item.CanEdit)
            await Shell.Navigation.GoToAsync(UserPages.Edit, item.User.Id, NavigationDirection.Forward);
    }

    [RelayCommand(CanExecute = nameof(CanEdit))]
    private async Task EditActiveItem()
    {
        var item = mUsersSource.Items.FirstOrDefault(x => x.IsActive);

        if (item != null)
            await EditCommand.ExecuteAsync(item);
    }


    private Boolean CanDelete()
    {
        return !IsBusy;
    }

    [RelayCommand(CanExecute = nameof(CanDelete))]
    private async Task Delete(UserListItemViewModel item)
    {
        if (item.CanDelete)
        {
            var result = await Shell.MessageBox.ShowConfirmationAsync(
                ("users.msgbox-delete-question", item.Name!),
                "users.msgbox-delete-message",
                "users.msgbox-delete-accept",
                "users.msgbox-delete-cancel"
            );

            if (result == MessageBoxResult.Accept)
            {
                try
                {
                    IsBusy = true;

                    await UserManager.DeleteAsync(item.User.Id);

                    mUsersSource.Remove(item);

                    IsBusy = false;
                }
                catch (Exception exception)
                {
                    IsBusy = false;

                    await Shell.MessageBox.ShowErrorAsync("USR201", exception);
                }
            }
        }
    }

    [RelayCommand(CanExecute = nameof(CanDelete))]
    private async Task DeleteActiveItem()
    {
        var item = mUsersSource.Items.FirstOrDefault(x => x.IsActive);

        if (item != null)
            await Delete(item);
    }


    [RelayCommand]
    private void FocusSearchTextBox(TextBox? control)
    {
        control?.Focus();
    }


    protected override void OnIsBusyChanged()
    {
        base.OnIsBusyChanged();

        CreateCommand.NotifyCanExecuteChanged();
        EditCommand.NotifyCanExecuteChanged();
        EditActiveItemCommand.NotifyCanExecuteChanged();
        DeleteCommand.NotifyCanExecuteChanged();
        DeleteActiveItemCommand.NotifyCanExecuteChanged();
    }
}
