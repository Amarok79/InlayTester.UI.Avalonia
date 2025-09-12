// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

#pragma warning disable CA1815

using Microsoft.Extensions.Localization;


namespace Amarok.Fabric.Avalonia;


/// <summary>
///     Represents a localizable text resource, meaning, a text that is loaded and formatted via
///     <see cref="IStringLocalizer"/> at a later point.
/// </summary>
public readonly struct Localizable
{
    /// <summary>
    ///     The resource lookup key.
    /// </summary>
    public String ResourceKey { get; }

    /// <summary>
    ///     The optional format arguments.
    /// </summary>
    public Object[] Args { get; }


    /// <summary>
    ///     Initializes an empty text resource.
    /// </summary>
    public Localizable()
    {
        ResourceKey = String.Empty;
        Args        = [ ];
    }

    /// <summary>
    ///     Initializes a localizable text resource with the given resource key.
    /// </summary>
    public Localizable(String resourceKey)
    {
        ResourceKey = resourceKey;
        Args        = [ ];
    }

    /// <summary>
    ///     Initializes a localizable text resource with the given resource key and format arguments.
    /// </summary>
    public Localizable(String resourceKey, params Object[] args)
    {
        ResourceKey = resourceKey;
        Args        = args;
    }


    /// <summary>
    ///     Initializes a localizable text resource with the given resource key.
    /// </summary>
    public static implicit operator Localizable(String resourceKey)
    {
        return new Localizable(resourceKey);
    }

    /// <summary>
    ///     Initializes a localizable text resource with the given resource key and format arguments.
    /// </summary>
    public static implicit operator Localizable((String resourceKey, Object arg1) tuple)
    {
        return new Localizable(tuple.resourceKey, tuple.arg1);
    }

    /// <summary>
    ///     Initializes a localizable text resource with the given resource key and format arguments.
    /// </summary>
    public static implicit operator Localizable((String resourceKey, Object arg1, Object arg2) tuple)
    {
        return new Localizable(tuple.resourceKey, tuple.arg1, tuple.arg2);
    }

    /// <summary>
    ///     Initializes a localizable text resource with the given resource key and format arguments.
    /// </summary>
    public static implicit operator Localizable((String resourceKey, Object arg1, Object arg2, Object arg3) tuple)
    {
        return new Localizable(tuple.resourceKey, tuple.arg1, tuple.arg2, tuple.arg3);
    }

    /// <summary>
    ///     Initializes a localizable text resource with the given resource key and format arguments.
    /// </summary>
    public static implicit operator Localizable(
        (String resourceKey, Object arg1, Object arg2, Object arg3, Object arg4) tuple
    )
    {
        return new Localizable(
            tuple.resourceKey,
            tuple.arg1,
            tuple.arg2,
            tuple.arg3,
            tuple.arg4
        );
    }

    /// <summary>
    ///     Initializes a localizable text resource with the given resource key and format arguments.
    /// </summary>
    public static implicit operator Localizable(
        (String resourceKey, Object arg1, Object arg2, Object arg3, Object arg4, Object arg5) tuple
    )
    {
        return new Localizable(
            tuple.resourceKey,
            tuple.arg1,
            tuple.arg2,
            tuple.arg3,
            tuple.arg4,
            tuple.arg5
        );
    }

    /// <summary>
    ///     Initializes a localizable text resource with the given resource key and format arguments.
    /// </summary>
    public static implicit operator Localizable((String resourceKey, Object[] args) tuple)
    {
        return new Localizable(tuple.resourceKey, tuple.args);
    }


    /// <summary>
    ///     Returns the resource key.
    /// </summary>
    public override String ToString()
    {
        return $"[{ResourceKey}]";
    }

    /// <summary>
    ///     Gets the string resource with the given key and formatted with the supplied arguments.
    /// </summary>
    /// <param name="localizer">
    ///     The localizer instance to use.
    /// </param>
    /// <returns>
    ///     A locale specific string.
    /// </returns>
    public String GetString(IStringLocalizer localizer)
    {
        if (ResourceKey == null)
        {
            return String.Empty;
        }

        return Args == null || Args.Length == 0
            ? localizer.GetString(ResourceKey)
            : localizer.GetString(ResourceKey, Args);
    }
}
