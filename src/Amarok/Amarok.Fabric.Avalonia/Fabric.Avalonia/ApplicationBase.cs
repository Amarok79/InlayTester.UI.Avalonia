// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric.Avalonia.Infrastructure;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Amarok.Fabric.Avalonia;


public abstract class ApplicationBase : Application,
    IServiceProviderAware
{
    private IHost? mHost;
    private IContainer? mContainer;


    public IServiceProvider ServiceProvider => mContainer!;


    public sealed override void Initialize()
    {
        base.Initialize();

        var container = new ContainerFactory().Create(OnGetAssemblyIncludePatterns(), OnGetAssemblyExcludePatterns());

        var builder = new HostBuilderFactory().Create(OnGetApplicationBuilderSettings(), container);

        OnConfigureApplication(builder);

        mContainer = container;
        mHost      = builder.Build();

        DataTemplates.Add(container.GetRequiredService<IViewLocator>());
    }

    public sealed override void OnFrameworkInitializationCompleted()
    {
        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // instantiate main window
            desktop.MainWindow = OnCreateRootWindow(ServiceProvider.GetRequiredService<IViewFactory>());

            // register more services
            mContainer.Use(desktop.MainWindow.StorageProvider);
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleView)
        {
            // instantiate main view
            singleView.MainView = OnCreateRootView(ServiceProvider.GetRequiredService<IViewFactory>());
        }

        base.OnFrameworkInitializationCompleted();

        _ = OnInitializedAsync();
    }


    /// <summary>
    ///     Called to determine the assembly include patterns (globs), defining the application assemblies that get
    ///     loaded and scanned and which exported types are automatically registered in the dependency injection
    ///     container. Defaults to "*.dll".
    /// </summary>
    protected virtual IEnumerable<String> OnGetAssemblyIncludePatterns()
    {
        return [ "*.dll" ];
    }

    /// <summary>
    ///     Called to determine the assembly exclude patterns (globs), defining the application assemblies that get
    ///     loaded and scanned and which exported types are automatically registered in the dependency injection
    ///     container. Defaults to an empty list.
    /// </summary>
    protected virtual IEnumerable<String> OnGetAssemblyExcludePatterns()
    {
        return [ ];
    }

    /// <summary>
    ///     Called to obtain the <see cref="HostApplicationBuilderSettings"/> for constructing the
    ///     <see cref="HostApplicationBuilder"/>. Defaults to null.
    /// </summary>
    protected virtual HostApplicationBuilderSettings? OnGetApplicationBuilderSettings()
    {
        return null;
    }

    /// <summary>
    ///     Called to configure the <see cref="HostApplicationBuilder"/>.
    /// </summary>
    protected virtual void OnConfigureApplication(HostApplicationBuilder builder)
    {
    }

    /// <summary>
    ///     Called for <see cref="IClassicDesktopStyleApplicationLifetime"/> applications to obtain the root window.
    /// </summary>
    protected virtual Window OnCreateRootWindow(IViewFactory viewFactory)
    {
        return new Window();
    }

    /// <summary>
    ///     Called for <see cref="ISingleViewApplicationLifetime"/> applications to obtain the root view.
    /// </summary>
    protected virtual Control OnCreateRootView(IViewFactory viewFactory)
    {
        return new Panel();
    }

    /// <summary>
    ///     Called at the end of framework initialization to allow applications to configure startup or initial
    ///     steps, e.g. navigate to a home view, etc.
    /// </summary>
    /// <returns></returns>
    protected virtual Task OnInitializedAsync()
    {
        return Task.CompletedTask;
    }
}
