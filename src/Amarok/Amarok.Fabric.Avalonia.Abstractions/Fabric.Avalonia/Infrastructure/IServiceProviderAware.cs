// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.Fabric.Avalonia.Infrastructure;


public interface IServiceProviderAware
{
    public IServiceProvider ServiceProvider { get; }
}
