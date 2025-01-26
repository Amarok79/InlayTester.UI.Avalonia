// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using CommunityToolkit.Mvvm.ComponentModel;


namespace InlayTester.UI;


/// <summary>
///     A view model base class with additional busy state.
/// </summary>
public abstract partial class ViewModelWithBusy : ViewModelWithActivation
{
    /// <summary>
    ///     Indicates whether the application is busy and parts of the UI should get disabled.
    /// </summary>
    [ObservableProperty]
    private Boolean _IsBusy;


    /// <summary>
    ///     Called when the state of <see cref="IsBusy"/> changed.
    /// </summary>
    protected virtual void OnIsBusyChanged()
    {
    }


    partial void OnIsBusyChanged(Boolean value)
    {
        OnIsBusyChanged();
    }
}
