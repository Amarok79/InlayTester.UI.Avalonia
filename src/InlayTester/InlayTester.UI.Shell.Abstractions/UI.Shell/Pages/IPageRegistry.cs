// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


/// <summary>
///     The registry of Pages.
/// </summary>
public interface IPageRegistry
{
    /// <summary>
    ///     Gets the Page, or null.
    /// </summary>
    PageDescriptor? GetPage(String id);
}
