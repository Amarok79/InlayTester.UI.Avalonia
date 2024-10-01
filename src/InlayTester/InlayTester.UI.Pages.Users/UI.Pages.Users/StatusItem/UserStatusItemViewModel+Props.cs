// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;


namespace InlayTester.UI.Pages.Users;


partial class UserStatusItemViewModel
{
    [ObservableProperty]
    private Boolean _IsLoggedIn;

    [ObservableProperty]
    private MaterialIconKind _Icon = UsersIcons.Login;

    [ObservableProperty]
    private String _Text = String.Empty;

    [ObservableProperty]
    private String _ToolTip = String.Empty;
}
