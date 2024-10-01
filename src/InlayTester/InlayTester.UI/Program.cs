// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia;
using Avalonia.Logging;


namespace InlayTester;


internal static class Program
{
    [STAThread]
    public static Int32 Main(String[] args)
    {
        var builder = BuildAvaloniaApp();

        if (args.Contains("--drm"))
        {
            SilenceConsole();

            return builder.StartLinuxDrm(args, "/dev/dri/card1", 1.0);
        }

        return builder.StartWithClassicDesktopLifetime(args);
    }

    private static void SilenceConsole()
    {
        new Thread(
            () => {
                Console.CursorVisible = false;
                while (true)
                {
                    Console.ReadKey(true);
                }
            }
        ) { IsBackground = true }.Start();
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace(LogEventLevel.Information, LogArea.Binding);
    }
}
