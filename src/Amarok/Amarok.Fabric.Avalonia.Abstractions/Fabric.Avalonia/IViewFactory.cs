// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Controls;


namespace Amarok.Fabric.Avalonia;


/// <summary>
///     A service for constructing View Model and View instances.
/// </summary>
public interface IViewFactory
{
    /// <summary>
    ///     Constructs a new View Model instance of the given type. The instance is resolved from the dependency
    ///     injection container.
    /// </summary>
    /// <param name="viewModelType">
    ///     The type of the View Model. Must have been registered via <see cref="ExportAttribute{T}"/>.
    /// </param>
    /// <returns>
    ///     The newly constructed View Model instance.
    /// </returns>
    Object CreateViewModel(Type viewModelType);

    /// <summary>
    ///     Constructs a new View Model instance of the given type. The instance is resolved from the dependency
    ///     injection container.
    /// </summary>
    /// <typeparam name="TViewModel">
    ///     The type of the View Model. Must have been registered via <see cref="ExportAttribute{T}"/>.
    /// </typeparam>
    /// <returns>
    ///     The newly constructed View Model instance.
    /// </returns>
    TViewModel CreateViewModel<TViewModel>()
        where TViewModel : class
    {
        return (TViewModel)CreateViewModel(typeof(TViewModel));
    }

    /// <summary>
    ///     Constructs a new View Model instance for the given key. The instance is resolved from the dependency
    ///     injection container.
    /// </summary>
    /// <param name="viewModelContractKey">
    ///     The contract key of the View Model. Must have been registered via <see cref="ExportViewModelAttribute"/>
    ///     .
    /// </param>
    /// <returns>
    ///     The newly constructed View Model instance.
    /// </returns>
    Object CreateViewModel(String viewModelContractKey);


    /// <summary>
    ///     Constructs a new View instance of the given type.
    /// </summary>
    /// <param name="viewType">
    ///     The type of the View. A <see cref="Control"/> or a subclass of it.
    /// </param>
    /// <returns>
    ///     The newly constructed View instance.
    /// </returns>
    Control CreateView(Type viewType);

    /// <summary>
    ///     Constructs a new View instance of the given type.
    /// </summary>
    /// <typeparam name="TView">
    ///     The type of the View. A <see cref="Control"/> or a subclass of it.
    /// </typeparam>
    /// <returns>
    ///     The newly constructed View instance.
    /// </returns>
    TView CreateView<TView>()
        where TView : Control, new()
    {
        return (TView)CreateView(typeof(TView));
    }


    /// <summary>
    ///     Constructs a new View instance, where the type of the View is determined from the given View Model, and
    ///     assigns the given View Model instance to the View's data context.
    /// </summary>
    /// <param name="viewModel">
    ///     The View Model instance.
    /// </param>
    /// <returns>
    ///     The newly constructed View instance with its data context set to the given View Model instance.
    /// </returns>
    Control CreateViewForViewModel(Object viewModel);


    /// <summary>
    ///     Constructs a new View Model instance of the given type, determines the associated View type, constructs a
    ///     new View instance, and assigns the constructed View Model instance to the View's data context. The View
    ///     Model instance is resolved from the dependency injection container.
    /// </summary>
    /// <param name="viewModelType">
    ///     The type of the View Model. Must have been registered via <see cref="ExportAttribute{T}"/>.
    /// </param>
    /// <returns>
    ///     The newly constructed View instance with its data context set to the newly constructed View Model
    ///     instance.
    /// </returns>
    Control CreateViewModelAndView(Type viewModelType);

    /// <summary>
    ///     Constructs a new View Model instance of the given type, determines the associated View type, constructs a
    ///     new View instance, and assigns the constructed View Model instance to the View's data context. The View
    ///     Model instance is resolved from the dependency injection container.
    /// </summary>
    /// <typeparam name="TViewModel">
    ///     The type of the View Model. Must have been registered via <see cref="ExportAttribute{T}"/>.
    /// </typeparam>
    /// <typeparam name="TView">
    ///     The type of the View. A <see cref="Control"/> or a subclass of it.
    /// </typeparam>
    /// <returns>
    ///     The newly constructed View instance with its data context set to the newly constructed View Model
    ///     instance.
    /// </returns>
    TView CreateViewModelAndView<TViewModel, TView>()
        where TView : Control, new()
    {
        return (TView)CreateViewModelAndView(typeof(TViewModel));
    }

    /// <summary>
    ///     Constructs a new View Model instance for the given key, determines the associated View type, constructs a
    ///     new View instance, and assigns the constructed View Model instance to the View's data context. The View
    ///     Model instance is resolved from the dependency injection container.
    /// </summary>
    /// <param name="viewModelContractKey">
    ///     The contract key of the View Model. Must have been registered via <see cref="ExportViewModelAttribute"/>
    ///     .
    /// </param>
    /// <returns>
    ///     The newly constructed View instance with its data context set to the newly constructed View Model
    ///     instance.
    /// </returns>
    Control CreateViewModelAndView(String viewModelContractKey);
}
