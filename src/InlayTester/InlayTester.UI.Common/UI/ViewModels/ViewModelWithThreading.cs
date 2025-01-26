// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;


namespace InlayTester.UI;


/// <summary>
///     A view model base class with additional threading support.
/// </summary>
public abstract class ViewModelWithThreading : ViewModelWithLogger
{
    /// <summary>
    ///     The thread helper (injected)
    /// </summary>
    [Import]
    public required IThreadHelper Threading { get; set; }
}
