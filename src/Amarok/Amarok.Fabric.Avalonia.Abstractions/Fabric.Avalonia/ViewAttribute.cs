// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Controls;
using CommunityToolkit.Diagnostics;


namespace Amarok.Fabric.Avalonia;


/// <summary>
///     An attribute that allows View Model classes to specify their corresponding View types. This can be used
///     as an alternative to realizing the <see cref="IViewAware"/> interface in View Model classes.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ViewAttribute : Attribute
{
    /// <summary>
    ///     The type of the corresponding View. A <see cref="Control"/> or a subclass of it.
    /// </summary>
    public Type ViewType { get; }


    /// <summary>
    ///     Instantiates a new instance.
    /// </summary>
    /// <param name="viewType">
    ///     The type of the corresponding View. A <see cref="Control"/> or a subclass of it.
    /// </param>
    public ViewAttribute(Type viewType)
    {
        Guard.IsTrue(typeof(Control).IsAssignableFrom(viewType));

        ViewType = viewType;
    }
}
