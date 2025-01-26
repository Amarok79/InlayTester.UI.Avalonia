// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Avalonia.Threading;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;


namespace InlayTester.UI;


/// <summary>
///     A view model base class with additional busy progress state.
/// </summary>
public abstract partial class ViewModelWithBusyProgress : ViewModelWithBusy
{
    private DispatcherTimer? mTimer;


    /// <summary>
    ///     Indicates whether the busy progress should be shown.
    /// </summary>
    [ObservableProperty]
    public partial Boolean IsBusyProgressVisible { get; set; }

    protected override Task OnActivatedAsync()
    {
        if (IsBusy)
        {
            _StartTimer();
        }

        return base.OnActivatedAsync();
    }

    protected override Task OnDeactivatedAsync()
    {
        // clean up resources
        mTimer?.Stop();

        // make sure progress is hidden
        IsBusyProgressVisible = false;

        return base.OnDeactivatedAsync();
    }

    protected override void OnIsBusyChanged()
    {
        base.OnIsBusyChanged();

        if (IsDeactivating)
        {
            return;
        }

        if (IsBusy)
        {
            _StartTimer();
        }
        else
        {
            mTimer?.Stop();

            IsBusyProgressVisible = false;
        }
    }


    private void _StartTimer()
    {
        if (mTimer == null)
        {
            _CreateTimer();
        }

        Guard.IsNotNull(mTimer);

        mTimer.Start();
    }

    private void _CreateTimer()
    {
        mTimer          =  new DispatcherTimer();
        mTimer.Interval =  TimeSpan.FromMilliseconds(500);
        mTimer.Tick     += _TimerTick;
    }

    private void _TimerTick(Object? sender, EventArgs e)
    {
        mTimer?.Stop();

        if (IsBusy && !IsDeactivating)
        {
            IsBusyProgressVisible = true;
        }
    }
}
