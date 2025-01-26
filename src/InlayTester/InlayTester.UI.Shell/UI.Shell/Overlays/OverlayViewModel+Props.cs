// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;


namespace InlayTester.UI.Shell;


partial class OverlayViewModel
{
    [ObservableProperty]
    private Boolean _IsOpen;

    [ObservableProperty]
    private Object? _Content;
}
