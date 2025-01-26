// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric.Avalonia;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.Input;
using InlayTester.Services;
using InlayTester.UI.Pages.Home;
using InlayTester.UI.Shell;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Serilog;


namespace InlayTester;


public class App : ApplicationBase
{
    public App()
    {
        AvaloniaXamlLoader.Load(this);
    }


    protected override IEnumerable<String> OnGetAssemblyIncludePatterns()
    {
        return [ "InlayTester.*.dll" ];
    }

    protected override IEnumerable<String> OnGetAssemblyExcludePatterns()
    {
        return [ ];
    }

    protected override HostApplicationBuilderSettings? OnGetApplicationBuilderSettings()
    {
        return null;
    }

    protected override void OnConfigureApplication(HostApplicationBuilder builder)
    {
        if (!Design.IsDesignMode)
        {
            _ConfigureConfiguration(builder);
            _ConfigureLogging(builder);
            _ConfigureUnhandledExceptions();
        }

        _ConfigureLocalization(builder);
    }

    private void _ConfigureConfiguration(HostApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("ui.config.json", true)
            .AddJsonFile("ui.config.development.json", true)
            .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "..", "config", "ui.config.json"), true)
            .AddCommandLine(Environment.GetCommandLineArgs());
    }

    private void _ConfigureLogging(HostApplicationBuilder builder)
    {
        builder.Services.AddSerilog(
            (_, loggerConfiguration) => loggerConfiguration.MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithThreadId()
                .WriteTo.Async(
                    x => x.File(
                        Path.Combine(AppContext.BaseDirectory, "..", "logs", "ui", "InlayTester.UI..log"),
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 31,
                        rollOnFileSizeLimit: true,
                        buffered: true,
                        flushToDiskInterval: TimeSpan.FromSeconds(5),
                        formatProvider: CultureInfo.InvariantCulture,
                        outputTemplate:
                        "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}] [{Level:u3}] [{ThreadId:000}] [{SourceContext}]  {Message:lj}{NewLine}{Exception}"
                    ),
                    4096,
                    true
                )
                .WriteTo.Seq("http://localhost:5341")
        );
    }

    private void _ConfigureUnhandledExceptions()
    {
        AppDomain.CurrentDomain.UnhandledException += (_, args) => {
            var logger = ServiceProvider.GetService<ILogger<App>>() ?? NullLogger<App>.Instance;
            logger.LogError(args.ExceptionObject as Exception, "*** UNHANDLED EXCEPTION");
        };
    }

    private void _ConfigureLocalization(HostApplicationBuilder builder)
    {
        var translationDir = Path.Combine(AppContext.BaseDirectory, "translations");
        var localizer      = new BuiltInStringLocalizer(translationDir);
        builder.Services.AddSingleton<IStringLocalizer>(localizer);
    }


    protected override Window OnCreateRootWindow(IViewFactory viewFactory)
    {
        return viewFactory.CreateViewModelAndView<ShellWindowViewModel, ShellWindow>();
    }

    protected override Control OnCreateRootView(IViewFactory viewFactory)
    {
        return viewFactory.CreateViewModelAndView<ShellViewModel, ShellView>();
    }


    protected override async Task OnInitializedAsync()
    {
        var logger = ServiceProvider.GetRequiredService<ILogger<App>>();

        logger.LogInformation(
            "--------------------------------------------------------------------------------"
        );


        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var configuration = ServiceProvider.GetRequiredService<IConfiguration>();

            if (desktop.MainWindow != null && configuration.GetValue("avalonia:dev-tools", false))
            {
                desktop.MainWindow.AttachDevTools();
            }
        }


        var shell = ServiceProvider.GetRequiredService<IShell>();

        shell.WindowIcon =
            new WindowIcon(AssetLoader.Open(new Uri("avares://InlayTester.UI/Assets/app.png")));

        shell.WindowTitle = "Inlay Tester UI";

        shell.HomeCommand = new AsyncRelayCommand(
            async () => {
                if (shell.IsHomeButtonVisible)
                {
                    await shell.Navigation.GoToAsync(HomePages.Home, NavigationDirection.Backward);
                }
            }
        );


        await Task.Delay(1000);

        await shell.Navigation.GoToAsync(HomePages.Home, NavigationDirection.Forward);

        //await shell.Navigation.GoToAsync(new PageId("USER/LIST"), NavigationDirection.Forward);
    }
}
