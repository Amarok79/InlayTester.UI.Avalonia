// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Controls;


namespace Amarok.Fabric.Avalonia;


/// <summary>
///     An interface that allows View Model classes to specify their corresponding View types. This can
///     be used as an alternative to applying the <see cref="ViewAttribute"/> decoration to View Model
///     classes.
/// </summary>
public interface IViewAware
{
    /// <summary>
    ///     Returns the type of the View that corresponds with this View Model. Returns a
    ///     <see cref="Control"/> or a subclass of it.
    /// </summary>
    Type ViewType { get; }
}
