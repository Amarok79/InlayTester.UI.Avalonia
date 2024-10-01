// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


/// <summary>
///     Describes a single Page.
/// </summary>
public sealed class PageDescriptor
{
    /// <summary>
    ///     The id of the Page.
    /// </summary>
    public String Id { get; }

    /// <summary>
    ///     The type of the associated View Model.
    /// </summary>
    public Type ViewModelType { get; }


    private PageDescriptor(String id, Type viewModelType)
    {
        Id = id;
        ViewModelType = viewModelType;
    }


    /// <summary>
    ///     Creates a new descriptor.
    /// </summary>
    public static PageDescriptor For(String id, Type viewModelType)
    {
        return new PageDescriptor(id, viewModelType);
    }

    /// <summary>
    ///     Creates a new descriptor.
    /// </summary>
    public static PageDescriptor For<TViewModel>(String id)
    {
        return new PageDescriptor(id, typeof(TViewModel));
    }
}
