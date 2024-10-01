// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;


namespace InlayTester.UI.Shell;


partial class ShellViewModel
{
    [ObservableProperty]
    private Boolean _IsBaseLayerEnabled = true;

    [ObservableProperty]
    private Boolean _IsMessageBoxLayerEnabled = true;

    [ObservableProperty]
    private Boolean _IsOverlayLayerEnabled = true;


    [ObservableProperty]
    private String? _WindowTitle;

    [ObservableProperty]
    private WindowIcon? _WindowIcon;

    [ObservableProperty]
    private String? _PageTitle;

    [ObservableProperty]
    private Object? _Page;

    [ObservableProperty]
    private Boolean _IsPageTransitionReversed;

    [ObservableProperty]
    private Boolean _IsHomeButtonVisible;

    [ObservableProperty]
    private ICommand? _HomeCommand;

    [ObservableProperty]
    private Boolean _IsUserStatusItemEnabled;
}
