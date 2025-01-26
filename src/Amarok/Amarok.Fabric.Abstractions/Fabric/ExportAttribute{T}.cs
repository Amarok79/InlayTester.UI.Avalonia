// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using DryIocAttributes;


namespace Amarok.Fabric;


/// <summary>
///     Specifies that a type provides a particular export.
/// </summary>
/// <typeparam name="T">
///     The type to export.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class ExportAttribute<T> : ExportExAttribute
{
    /// <summary>
    ///     Instantiates a new instance.
    /// </summary>
    public ExportAttribute()
        : base(typeof(T))
    {
    }
}
