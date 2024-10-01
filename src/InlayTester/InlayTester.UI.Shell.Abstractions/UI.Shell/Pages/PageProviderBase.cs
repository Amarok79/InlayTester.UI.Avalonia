// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;


namespace InlayTester.UI.Shell;


/// <summary>
///     A base class implementation of <see cref="IPageProvider"/> which automatically exports itself
///     as Page provider.
/// </summary>
[InheritedExport<IPageProvider>]
public abstract class PageProviderBase : IPageProvider
{
    public IEnumerable<PageDescriptor> GetPages()
    {
        return OnGetPages();
    }


    /// <summary>
    ///     Invoked to query the Page descriptors.
    /// </summary>
    protected abstract IEnumerable<PageDescriptor> OnGetPages();
}
