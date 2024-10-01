// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using InlayTester.Domain;
using Microsoft.Extensions.Logging;


namespace InlayTester.UI.Shell.NavigationService;


[Export<INavigationService>]
internal sealed class NavigationService : INavigationService
{
    private readonly Lazy<INavigationHost> mNavigationHost;
    private readonly IViewFactory mViewFactory;
    private readonly IPageRegistry mPageRegistry;
    private readonly ILogger<NavigationService> mLogger;


    public NavigationService(
        Lazy<INavigationHost> navigationHost,
        IViewFactory viewFactory,
        IPageRegistry pageRegistry,
        ILogger<NavigationService> logger
    )
    {
        mNavigationHost = navigationHost;
        mViewFactory = viewFactory;
        mPageRegistry = pageRegistry;
        mLogger = logger;
    }


    public Task GoToAsync(String id, NavigationDirection direction)
    {
        return GoToAsync(id, null, direction);
    }

    public async Task GoToAsync(String id, String? arg, NavigationDirection direction)
    {
        mLogger.LogInformation("Goto {Page}, {Arg}, {Direction}", id, arg, direction);

        var page = id.IsNullOrWhitespace() ? null : mPageRegistry.GetPage(id);


        var currentViewModel = mNavigationHost.Value.Page;

        if (currentViewModel is INavigationAware currentNavigationAware)
            await currentNavigationAware.LeaveAsync();

        if (currentViewModel is IDisposable currentDisposable)
            currentDisposable.Dispose();


        var newViewModel = page != null ? mViewFactory.CreateViewModel(page.ViewModelType) : null;

        if (newViewModel is INavigationAware newNavigationAware1)
            await newNavigationAware1.InitializeAsync(arg);

        mNavigationHost.Value.IsPageTransitionReversed = direction == NavigationDirection.Backward;
        mNavigationHost.Value.Page = newViewModel;

        await Task.Delay(150);

        if (newViewModel is INavigationAware newNavigationAware2)
            await newNavigationAware2.EnterAsync();
    }
}
