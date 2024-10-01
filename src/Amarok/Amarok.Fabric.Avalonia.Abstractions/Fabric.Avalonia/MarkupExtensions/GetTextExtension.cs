// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric.Avalonia.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;


namespace Amarok.Fabric.Avalonia.MarkupExtensions;


/// <summary>
///     A XAML markup extension for looking up a localized text.
/// </summary>
public sealed class GetTextExtension
{
    private readonly String mResourceKey;


    public GetTextExtension(String resourceKey)
    {
        mResourceKey = resourceKey;
    }


    public String ProvideValue()
    {
        var localizer = ServiceProviderLocator.Get().GetRequiredService<IStringLocalizer>();

        return localizer.GetString(mResourceKey);
    }
}
