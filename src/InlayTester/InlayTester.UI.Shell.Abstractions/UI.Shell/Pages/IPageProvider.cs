// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


/// <summary>
///     A service that provides Page descriptors.
/// </summary>
public interface IPageProvider
{
    /// <summary>
    ///     Gets an enumeration of Page descriptors.
    /// </summary>
    IEnumerable<PageDescriptor> GetPages();
}
