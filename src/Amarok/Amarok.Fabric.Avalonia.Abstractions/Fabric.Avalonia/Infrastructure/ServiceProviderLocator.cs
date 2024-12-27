// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia;
using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;


namespace Amarok.Fabric.Avalonia.Infrastructure;


public static class ServiceProviderLocator
{
    private static Lazy<IServiceProvider> sServiceProvider = new(_ResolveServiceProvider);
    private static Lazy<IStringLocalizer> sLocalizer = new(_ResolveLocalizer);
    private static Lazy<IViewFactory> sViewFactory = new(_ResolveViewFactory);


    private static IServiceProvider _ResolveServiceProvider()
    {
        if (Application.Current is IServiceProviderAware serviceProviderAware)
        {
            return serviceProviderAware.ServiceProvider;
        }

        ThrowHelper.ThrowInvalidOperationException(
            "Unable to resolve IServiceProvider via Application.Current. Make sure to inherit " +
            "your application from ApplicationBase or realize IServiceProviderAware manually."
        );

        return null;
    }

    private static IStringLocalizer _ResolveLocalizer()
    {
        return ServiceProvider.GetRequiredService<IStringLocalizer>();
    }

    private static IViewFactory _ResolveViewFactory()
    {
        return ServiceProvider.GetRequiredService<IViewFactory>();
    }


    public static IServiceProvider ServiceProvider => sServiceProvider.Value;

    public static IStringLocalizer Localizer => sLocalizer.Value;

    public static IViewFactory ViewFactory => sViewFactory.Value;


    public static void ClearCache()
    {
        sServiceProvider = new Lazy<IServiceProvider>(_ResolveServiceProvider);
        sLocalizer       = new Lazy<IStringLocalizer>(_ResolveLocalizer);
        sViewFactory     = new Lazy<IViewFactory>(_ResolveViewFactory);
    }
}
