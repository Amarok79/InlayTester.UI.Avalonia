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
    public partial Boolean IsNameEnabled { get; set; }

    [ObservableProperty]
    public partial Boolean IsRolesEnabled { get; set; }

    [ObservableProperty]
    public partial MaterialIconKind? PageIcon { get; set; }

    [ObservableProperty]
    public partial String? PageHeader { get; set; }

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [FieldRequired]
    [UniqueNameRequired]
    public partial String? Name { get; set; }

    [ObservableProperty]
    public partial Int32 MaxNameLength { get; set; } = User.MaxNameLength;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [FieldRequired]
    public partial String? Password1 { get; set; }

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [FieldRequired]
    [MatchingPasswordsRequired]
    public partial String? Password2 { get; set; }

    [ObservableProperty]
    public partial Int32 MaxPasswordLength { get; set; } = User.MaxPasswordLength;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [SingleRoleRequired]
    public partial Object? Roles { get; set; }

    [ObservableProperty]
    public partial Boolean MachineOperator { get; set; }

    [ObservableProperty]
    public partial Boolean MachineSetter { get; set; }

    [ObservableProperty]
    public partial Boolean Administrator { get; set; }

    [ObservableProperty]
    public partial String? Notes { get; set; }

    [ObservableProperty]
    public partial Int32 MaxNotesLength { get; set; } = User.MaxNotesLength;

    [ObservableProperty]
    public partial String? AcceptLabel { get; set; }

    [ObservableProperty]
    public partial String? CancelLabel { get; set; }
}
