// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok;
using Amarok.Fabric.Avalonia.Infrastructure;
using Avalonia;
using Avalonia.Headless;
using Avalonia.Markup.Xaml;
using Moq;


[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]


namespace Amarok;


public class TestApp : Application,
    IServiceProviderAware
{
    public static Mock<IServiceProvider> ServiceProviderMock { get; } = new(MockBehavior.Strict);

    public IServiceProvider ServiceProvider => ServiceProviderMock.Object;


    public TestApp()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

public static class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<TestApp>()
            .UseHeadless(
                new AvaloniaHeadlessPlatformOptions {
                    UseHeadlessDrawing = false,
                }
            );
    }
}
