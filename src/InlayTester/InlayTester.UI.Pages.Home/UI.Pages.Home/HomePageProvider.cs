// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;
using InlayTester.UI.Pages.Home.Home;
using InlayTester.UI.Shell;


namespace InlayTester.UI.Pages.Home;


[Transient]
internal sealed class HomePageProvider : PageProviderBase
{
    protected override IEnumerable<PageDescriptor> OnGetPages()
    {
        yield return PageDescriptor.For<HomeViewModel>(HomePages.Home);
    }
}
