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
    public partial Boolean IsActive { get; set; }

    [ObservableProperty]
    public partial String? Name { get; set; }

    [ObservableProperty]
    public partial String? Roles { get; set; }

    [ObservableProperty]
    public partial String? LastModified { get; set; }
}
