// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;
using InlayTester.Domain;


namespace InlayTester.UI.Pages.Users;


public partial class UserListItemViewModel : ObservableObject
{
    public required User User { get; set; }

    public required UserListViewModel Parent { get; set; }


    public Boolean CanDelete => User.CanDelete();

    public Boolean CanEdit => User.CanEdit();


    [ObservableProperty]
    private Boolean _IsActive;

    [ObservableProperty]
    private String? _Name;

    [ObservableProperty]
    private String? _Roles;

    [ObservableProperty]
    private String? _LastModified;
}
