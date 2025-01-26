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
    private MaterialIconKind? _PageIcon;

    [ObservableProperty]
    private String? _PageHeader;

    [ObservableProperty]
    private String? _SearchText;

    [ObservableProperty]
    private Int32 _MaxSearchTextLength = User.MaxNameLength;

    [ObservableProperty]
    private ReadOnlyObservableCollection<UserListItemViewModel> _Users = null!;
}
