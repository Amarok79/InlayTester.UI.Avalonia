// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;
using InlayTester.Domain;
using Material.Icons;


namespace InlayTester.UI.Pages.Users;


partial class UserEditViewModel
{
    public Boolean HasUniqueName { get; set; } = true;


    [ObservableProperty]
    private Boolean _IsNameEnabled;

    [ObservableProperty]
    private Boolean _IsRolesEnabled;


    [ObservableProperty]
    private MaterialIconKind? _PageIcon;

    [ObservableProperty]
    private String? _PageHeader;


    [ObservableProperty] [NotifyDataErrorInfo] [FieldRequired] [UniqueNameRequired]
    private String? _Name;

    [ObservableProperty]
    private Int32 _MaxNameLength = User.MaxNameLength;

    [ObservableProperty] [NotifyDataErrorInfo] [FieldRequired]
    private String? _Password1;

    [ObservableProperty] [NotifyDataErrorInfo] [FieldRequired] [MatchingPasswordsRequired]
    private String? _Password2;

    [ObservableProperty]
    private Int32 _MaxPasswordLength = User.MaxPasswordLength;

    [ObservableProperty] [NotifyDataErrorInfo] [SingleRoleRequired]
    private Object? _Roles;

    [ObservableProperty]
    private Boolean _MachineOperator;

    [ObservableProperty]
    private Boolean _MachineSetter;

    [ObservableProperty]
    private Boolean _Administrator;

    [ObservableProperty]
    private String? _Notes;

    [ObservableProperty]
    private Int32 _MaxNotesLength = User.MaxNotesLength;


    [ObservableProperty]
    private String? _AcceptLabel;

    [ObservableProperty]
    private String? _CancelLabel;
}
