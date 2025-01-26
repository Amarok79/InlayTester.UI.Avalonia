// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using InlayTester.Domain;


namespace InlayTester.UI.Pages.Users;


partial class LoginOverlayViewModel
{
    public User? UserToValidate { get; set; }


    [ObservableProperty]
    public partial ObservableCollection<User> Users { get; set; } = [ ];

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [FieldRequired]
    public partial User? SelectedUser { get; set; }

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [FieldRequired]
    [PasswordMismatch]
    public partial String? Password { get; set; }

    [ObservableProperty]
    public partial Int32 MaxPasswordLength { get; set; } = User.MaxPasswordLength;
}
