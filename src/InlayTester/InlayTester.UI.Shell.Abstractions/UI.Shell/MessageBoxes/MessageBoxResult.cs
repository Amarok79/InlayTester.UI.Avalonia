// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


/// <summary>
///     The result of the message box.
/// </summary>
public enum MessageBoxResult
{
    /// <summary>
    ///     No result. The message box was closed programmatically.
    /// </summary>
    None,

    /// <summary>
    ///     The user selected "Cancel".
    /// </summary>
    Cancel,

    /// <summary>
    ///     The user selected "Accept".
    /// </summary>
    Accept,
}
