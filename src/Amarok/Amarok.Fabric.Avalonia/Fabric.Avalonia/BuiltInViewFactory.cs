// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Reflection;
using Amarok.Fabric.Avalonia.Infrastructure;
using Avalonia.Controls;
using CommunityToolkit.Diagnostics;
using DryIoc;
using Microsoft.Extensions.DependencyInjection;
using IContainer = DryIoc.IContainer;


namespace Amarok.Fabric.Avalonia;


[Export<IViewFactory>]
internal sealed class BuiltInViewFactory : IViewFactory
{
    private readonly IContainer mContainer;


    public BuiltInViewFactory(IContainer container)
    {
        mContainer = container;
    }


    public Object CreateViewModel(Type viewModelType)
    {
        Guard.IsNotNull(viewModelType);

        return mContainer.Resolve(viewModelType);
    }

    public Object CreateViewModel(String viewModelContractKey)
    {
        Guard.IsNotNullOrEmpty(viewModelContractKey);

        return mContainer.Resolve(typeof(ViewModelRegistration), viewModelContractKey);
    }


    public Control CreateView(Type viewType)
    {
        Guard.IsNotNull(viewType);

        return (Control)ActivatorUtilities.CreateInstance(mContainer, viewType);
    }


    public Control CreateViewForViewModel(Object viewModel)
    {
        Guard.IsNotNull(viewModel);

        var viewType = _GetViewTypeFromViewModel(viewModel);

        var view = CreateView(viewType);

        view.DataContext = viewModel;

        if (view.DataContext is IActivationAware activationAware)
        {
            view.Loaded   += (sender, args) => _ = activationAware.ActivatedAsync();
            view.Unloaded += (sender, args) => _ = activationAware.DeactivatedAsync();
        }

        return view;
    }


    public Control CreateViewModelAndView(Type viewModelType)
    {
        var viewModel = CreateViewModel(viewModelType);

        return CreateViewForViewModel(viewModel);
    }

    public Control CreateViewModelAndView(String viewModelContractKey)
    {
        var viewModel = CreateViewModel(viewModelContractKey);

        return CreateViewForViewModel(viewModel);
    }


    private static Type _GetViewTypeFromViewModel(Object viewModel)
    {
        if (viewModel is IViewAware viewAware)
        {
            return viewAware.ViewType;
        }

        var viewType = viewModel.GetType().GetCustomAttribute<ViewAttribute>()?.ViewType;

        if (viewType != null)
        {
            return viewType;
        }

        throw new ArgumentException(
            $"Unable to determine the View associated with a View Model. The View Model type '{
                viewModel.GetType().FullName}' is not annotated with attribute '{
                    typeof(ViewAttribute).FullName}' nor does it realize interface '{
                        typeof(IViewAware).FullName}'."
        );
    }
}
