// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using InlayTester.UI.Shell;


namespace InlayTester.UI.Pages.Users;


public static class ShellExtensions
{
    public static async Task<Boolean> ShowLoginAsync(this IShell shell)
    {
        var result = await shell.Overlay.ShowAsync(UserOverlays.Login);

        return Convert.ToBoolean(result, CultureInfo.InvariantCulture);
    }
}
