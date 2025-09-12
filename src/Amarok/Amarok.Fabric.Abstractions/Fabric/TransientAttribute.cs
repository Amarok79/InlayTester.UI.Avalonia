// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using DryIocAttributes;


namespace Amarok.Fabric;


/// <summary>
///     Defines a transient lifetime for exported types, meaning new instances are constructed every
///     time a type is resolved.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class TransientAttribute : TransientReuseAttribute
{
}
