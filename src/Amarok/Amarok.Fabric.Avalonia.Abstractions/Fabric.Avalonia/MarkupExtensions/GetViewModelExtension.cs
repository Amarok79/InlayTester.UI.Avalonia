// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric.Avalonia.Infrastructure;


namespace Amarok.Fabric.Avalonia.MarkupExtensions;


/// <summary>
///     A XAML markup extension for retrieving a View Model instance.
/// </summary>
public sealed class GetViewModelExtension
{
    private readonly String? mContractKey;
    private readonly Type? mType;


    public GetViewModelExtension(String contractKey)
    {
        mContractKey = contractKey;
    }

    public GetViewModelExtension(Type type)
    {
        mType = type;
    }


    public Object ProvideValue()
    {
        var viewFactory = ServiceProviderLocator.ViewFactory;

        return mType != null
            ? viewFactory.CreateViewModel(mType)
            : viewFactory.CreateViewModel(mContractKey!);
    }
}
