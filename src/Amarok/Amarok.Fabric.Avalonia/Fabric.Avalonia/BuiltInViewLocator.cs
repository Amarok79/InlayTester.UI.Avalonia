// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel;
using Avalonia.Controls;


namespace Amarok.Fabric.Avalonia;


[Export<IViewLocator>]
internal sealed class BuiltInViewLocator : IViewLocator
{
    private readonly IViewFactory mViewFactory;


    public BuiltInViewLocator(IViewFactory viewFactory)
    {
        mViewFactory = viewFactory;
    }


    public Boolean Match(Object? data)
    {
        if (data is INotifyPropertyChanged)
        {
            data = data.GetType();
        }

        if (data is Type type)
        {
            return typeof(IViewAware).IsAssignableFrom(type) ||
                   Attribute.IsDefined(type, typeof(ViewAttribute));
        }

        return false;
    }

    public Control? Build(Object? data)
    {
        var control = data switch {
            null      => null,
            Type type => mViewFactory.CreateViewModelAndView(type),
            _         => mViewFactory.CreateViewForViewModel(data),
        };

        return control;
    }
}
