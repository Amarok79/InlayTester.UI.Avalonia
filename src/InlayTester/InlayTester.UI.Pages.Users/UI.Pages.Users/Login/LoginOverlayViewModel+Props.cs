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
    private ObservableCollection<User> _Users = [ ];

    [ObservableProperty] [NotifyDataErrorInfo] [FieldRequired]
    private User? _SelectedUser;

    [ObservableProperty] [NotifyDataErrorInfo] [FieldRequired] [PasswordMismatch]
    private String? _Password;

    [ObservableProperty]
    private Int32 _MaxPasswordLength = User.MaxPasswordLength;
}
