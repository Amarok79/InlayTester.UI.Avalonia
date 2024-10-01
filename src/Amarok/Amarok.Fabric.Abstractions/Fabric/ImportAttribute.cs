// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using DryIocAttributes;


namespace Amarok.Fabric;


/// <summary>
///     Specifies that a property or field should be provided from the dependency injection container.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class ImportAttribute : ImportExAttribute
{
    /// <summary>
    ///     Instantiates a new instance.
    /// </summary>
    public ImportAttribute()
        : base(null)
    {
    }
}
