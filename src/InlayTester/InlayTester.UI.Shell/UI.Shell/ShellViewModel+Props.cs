// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;


namespace InlayTester.UI.Shell;


partial class ShellViewModel
{
    [ObservableProperty]
    public partial Boolean IsBaseLayerEnabled { get; set; } = true;

    [ObservableProperty]
    public partial Boolean IsMessageBoxLayerEnabled { get; set; } = true;

    [ObservableProperty]
    public partial Boolean IsOverlayLayerEnabled { get; set; } = true;

    [ObservableProperty]
    public partial String? WindowTitle { get; set; }

    [ObservableProperty]
    public partial WindowIcon? WindowIcon { get; set; }

    [ObservableProperty]
    public partial String? PageTitle { get; set; }

    [ObservableProperty]
    public partial Object? Page { get; set; }

    [ObservableProperty]
    public partial Boolean IsPageTransitionReversed { get; set; }

    [ObservableProperty]
    public partial Boolean IsHomeButtonVisible { get; set; }

    [ObservableProperty]
    public partial ICommand? HomeCommand { get; set; }

    [ObservableProperty]
    public partial Boolean IsUserStatusItemEnabled { get; set; }
}
