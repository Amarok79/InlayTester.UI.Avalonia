// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia;
using CommunityToolkit.Diagnostics;


namespace Amarok.Fabric.Avalonia.Infrastructure;


public static class ServiceProviderLocator
{
    private static Lazy<IServiceProvider> sLazy = new(_Resolve);


    private static IServiceProvider _Resolve()
    {
        if (Application.Current is IServiceProviderAware serviceProviderAware)
            return serviceProviderAware.ServiceProvider;

        ThrowHelper.ThrowInvalidOperationException(
            "Unable to resolve IServiceProvider via Application.Current. Make sure to inherit " +
            "your application from ApplicationBase or realize IServiceProviderAware manually."
        );

        return null;
    }


    public static IServiceProvider Get()
    {
        return sLazy.Value;
    }

    public static void ClearCache()
    {
        sLazy = new Lazy<IServiceProvider>(_Resolve);
    }
}
