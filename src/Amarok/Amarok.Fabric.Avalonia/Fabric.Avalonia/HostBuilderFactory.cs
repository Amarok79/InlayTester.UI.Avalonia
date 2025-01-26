// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Amarok.Fabric.Avalonia;


internal sealed class HostBuilderFactory
{
    public HostApplicationBuilder Create(HostApplicationBuilderSettings? settings, IContainer container)
    {
        var builder = Host.CreateEmptyApplicationBuilder(settings);
        builder.ConfigureContainer(new DryIocServiceProviderFactory(container, RegistrySharing.Share));
        return builder;
    }
}
