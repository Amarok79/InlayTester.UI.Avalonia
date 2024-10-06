// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using DryIocAttributes;


namespace Amarok.Fabric;


/// <summary>
///     Defines a singleton lifetime for exported types, meaning the same (single) instance is returned
///     every time a type is resolved.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public sealed class SingletonAttribute : SingletonReuseAttribute
{
}
