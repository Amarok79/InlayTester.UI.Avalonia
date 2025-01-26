// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;


namespace InlayTester.UI.Pages.Users;


partial class UserStatusItemViewModel
{
    [ObservableProperty]
    public partial Boolean IsLoggedIn { get; set; }

    [ObservableProperty]
    public partial MaterialIconKind Icon { get; set; } = UsersIcons.Login;

    [ObservableProperty]
    public partial String Text { get; set; } = String.Empty;

    [ObservableProperty]
    public partial String ToolTip { get; set; } = String.Empty;
}
