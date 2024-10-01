// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;


namespace InlayTester.UI.Shell;


partial class MessageBoxViewModel
{
    [ObservableProperty]
    private Boolean _IsOpen;

    [ObservableProperty]
    private MaterialIconKind _Icon;

    [ObservableProperty]
    private String? _Title;

    [ObservableProperty]
    private String? _Text;

    [ObservableProperty]
    private String? _AcceptText;

    [ObservableProperty]
    private String? _CancelText;

    [ObservableProperty]
    private Boolean _IsCancelVisible;

    [ObservableProperty]
    private Boolean _IsInfoStyle;

    [ObservableProperty]
    private Boolean _IsQuestionStyle;

    [ObservableProperty]
    private Boolean _IsWarningStyle;

    [ObservableProperty]
    private Boolean _IsErrorStyle;

    [ObservableProperty]
    private Boolean _IsAccentColorStyle;

    [ObservableProperty]
    private Boolean _IsWarningColorStyle;

    [ObservableProperty]
    private Boolean _IsDangerColorStyle;

    [ObservableProperty]
    private IRelayCommand? _AcceptCommand;

    [ObservableProperty]
    private IRelayCommand? _CancelCommand;
}
