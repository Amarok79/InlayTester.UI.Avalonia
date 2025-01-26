// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using DynamicData;
using InlayTester.Domain;
using Material.Icons;


namespace InlayTester.UI.Pages.Users;


partial class UserListViewModel
{
    private readonly SourceList<UserListItemViewModel> mUsersSource = new();


    [ObservableProperty]
    public partial MaterialIconKind? PageIcon { get; set; }

    [ObservableProperty]
    public partial String? PageHeader { get; set; }

    [ObservableProperty]
    public partial String? SearchText { get; set; }

    [ObservableProperty]
    public partial Int32 MaxSearchTextLength { get; set; } = User.MaxNameLength;

    [ObservableProperty]
    private ReadOnlyObservableCollection<UserListItemViewModel> _Users = null!;
}
