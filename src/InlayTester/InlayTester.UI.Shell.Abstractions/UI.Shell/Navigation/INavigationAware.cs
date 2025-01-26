// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


/// <summary>
///     An interface that page view models should implement in order to respond to navigation events.
/// </summary>
public interface INavigationAware
{
    /// <summary>
    ///     Called to initialize the page after construction but before becoming visible.
    /// </summary>
    Task InitializeAsync(String? arg);

    /// <summary>
    ///     Called when entering the page, shortly before becoming visible.
    /// </summary>
    Task EnterAsync();

    /// <summary>
    ///     Called before leaving the page.
    /// </summary>
    Task LeaveAsync();
}
