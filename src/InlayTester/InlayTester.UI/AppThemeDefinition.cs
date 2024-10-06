// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using ActiproSoftware.UI.Avalonia.Themes;
using ActiproSoftware.UI.Avalonia.Themes.Generation;


namespace InlayTester;


public sealed class AppThemeDefinition : ThemeDefinition
{
    public AppThemeDefinition()
    {
        BaseFontSize = 15.0;
        UserInterfaceDensity = UserInterfaceDensity.Spacious;

        ButtonAppearanceKind = ButtonAppearanceKind.Solid;
        CheckBoxAppearanceKind = SwitchAppearanceKind.Outline;

        Generator = new AppThemeGenerator();
    }
}
