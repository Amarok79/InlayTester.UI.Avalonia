// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;


namespace InlayTester.UI;


/// <summary>
///     A view model base class with additional threading support.
/// </summary>
public abstract class ViewModelWithThreading : ObservableValidator
{
    /// <summary>
    ///     The thread helper (injected)
    /// </summary>
    [Import]
    public required IThreadHelper Threading { get; set; }
}
