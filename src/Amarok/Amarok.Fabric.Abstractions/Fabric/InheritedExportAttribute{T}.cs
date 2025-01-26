// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel.Composition;


namespace Amarok.Fabric;


/// <summary>
///     Specifies that a type provides a particular export, and that subclasses of that type will also provide
///     that export.
/// </summary>
/// <typeparam name="T">
///     The type to export.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class InheritedExportAttribute<T> : InheritedExportAttribute
{
    /// <summary>
    ///     Instantiates a new instance.
    /// </summary>
    public InheritedExportAttribute()
        : base(typeof(T))
    {
    }
}
