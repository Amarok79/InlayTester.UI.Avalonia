// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;


namespace InlayTester.UI.Shell.PageRegistry;


[Export<IPageRegistry>]
internal sealed class PageRegistry : IPageRegistry
{
    private readonly Lazy<List<PageDescriptor>> mPages;


    public PageRegistry(IEnumerable<IPageProvider> providers)
    {
        mPages = new Lazy<List<PageDescriptor>>(_ResolvePages(providers));
    }

    private static List<PageDescriptor> _ResolvePages(IEnumerable<IPageProvider> providers)
    {
        var map = providers.SelectMany(provider => provider.GetPages())
            .ToDictionary(descriptor => descriptor.Id);

        return map.Values.ToList();
    }


    public PageDescriptor? GetPage(String id)
    {
        return mPages.Value.FirstOrDefault(x => String.Equals(x.Id, id, StringComparison.Ordinal));
    }
}
