// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


/// <summary>
///     Defines the direction of a page navigation.
/// </summary>
public enum NavigationDirection
{
    /// <summary>
    ///     Navigates forward, e.g. from a parent page to a sub-page
    /// </summary>
    Forward,

    /// <summary>
    ///     Navigates backward, e.g. from a sub-page to a parent page
    /// </summary>
    Backward,
}
