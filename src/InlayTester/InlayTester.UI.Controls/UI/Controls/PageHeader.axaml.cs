// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Avalonia;
using Avalonia.Controls.Primitives;
using Material.Icons;


namespace InlayTester.UI.Controls;


public class PageHeader : TemplatedControl
{
    #region Icon

    public static readonly StyledProperty<MaterialIconKind?> IconProperty =
        AvaloniaProperty.Register<PageHeader, MaterialIconKind?>(nameof(Icon));

    public MaterialIconKind? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #endregion

    #region Text

    public static readonly StyledProperty<String?> TextProperty =
        AvaloniaProperty.Register<PageHeader, String?>(nameof(Text));

    public String? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion
}
