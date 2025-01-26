// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Controls;


namespace Amarok.Fabric.Avalonia;


/// <summary>
///     An attribute that allows View Model classes to specify their corresponding View types. This can be used
///     as an alternative to realizing the <see cref="IViewAware"/> interface in View Model classes.
/// </summary>
/// <typeparam name="TView">
///     Specifies the corresponding View type. A <see cref="Control"/> or a subclass of it.
/// </typeparam>
public sealed class ViewAttribute<TView> : ViewAttribute
    where TView : Control
{
    /// <summary>
    ///     Instantiates a new instance.
    /// </summary>
    public ViewAttribute()
        : base(typeof(TView))
    {
    }
}
