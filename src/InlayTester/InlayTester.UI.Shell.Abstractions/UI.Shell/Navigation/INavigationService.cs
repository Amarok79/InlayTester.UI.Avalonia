// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


/// <summary>
///     A service for performing page navigation.
/// </summary>
public interface INavigationService
{
    /// <summary>
    ///     Navigates to the given page.
    /// </summary>
    Task GoToAsync(String id, NavigationDirection direction);

    /// <summary>
    ///     Navigates to the given page and supplied argument.
    /// </summary>
    Task GoToAsync(String id, String? arg, NavigationDirection direction);
}
