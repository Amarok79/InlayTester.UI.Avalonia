// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;


namespace InlayTester.UI.Shell;


partial class MessageBoxViewModel
{
    [ObservableProperty]
    public partial Boolean IsOpen { get; set; }

    [ObservableProperty]
    public partial MaterialIconKind Icon { get; set; }

    [ObservableProperty]
    public partial String? Title { get; set; }

    [ObservableProperty]
    public partial String? Text { get; set; }

    [ObservableProperty]
    public partial String? AcceptText { get; set; }

    [ObservableProperty]
    public partial String? CancelText { get; set; }

    [ObservableProperty]
    public partial Boolean IsCancelVisible { get; set; }

    [ObservableProperty]
    public partial Boolean IsInfoStyle { get; set; }

    [ObservableProperty]
    public partial Boolean IsQuestionStyle { get; set; }

    [ObservableProperty]
    public partial Boolean IsWarningStyle { get; set; }

    [ObservableProperty]
    public partial Boolean IsErrorStyle { get; set; }

    [ObservableProperty]
    public partial Boolean IsAccentColorStyle { get; set; }

    [ObservableProperty]
    public partial Boolean IsWarningColorStyle { get; set; }

    [ObservableProperty]
    public partial Boolean IsDangerColorStyle { get; set; }

    [ObservableProperty]
    public partial IRelayCommand? AcceptCommand { get; set; }

    [ObservableProperty]
    public partial IRelayCommand? CancelCommand { get; set; }
}
