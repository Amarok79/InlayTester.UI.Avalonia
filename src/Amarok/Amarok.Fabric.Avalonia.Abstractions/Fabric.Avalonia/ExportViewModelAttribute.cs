// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric.Avalonia.Infrastructure;
using DryIocAttributes;


namespace Amarok.Fabric.Avalonia;


/// <summary>
///     An attribute that allows View Model classes to be registered by key in the dependency injection
///     containers. This key is used later to create View Model instances without knowing the exact View Model
///     type.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class ExportViewModelAttribute : ExportExAttribute
{
    /// <summary>
    ///     Instantiates a new instance.
    /// </summary>
    public ExportViewModelAttribute(String contractKey)
        : base(contractKey, typeof(ViewModelRegistration))
    {
    }
}
