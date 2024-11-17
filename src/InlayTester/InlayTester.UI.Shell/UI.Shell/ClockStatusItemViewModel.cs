// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;


namespace InlayTester.UI.Shell;


[View<ClockStatusItem>]
[Export<ClockStatusItemViewModel>]
public partial class ClockStatusItemViewModel : ObservableObject,
    IActivationAware
{
    private readonly DispatcherTimer mTimer = new();

    private DateOnly? mLastDate;


    [ObservableProperty]
    private String _Text = String.Empty;

    [ObservableProperty]
    private String _ToolTip = String.Empty;


    public Task ActivatedAsync()
    {
        _Refresh();

        mTimer.Tick     += (_, _) => _Refresh();
        mTimer.Interval =  TimeSpan.FromMilliseconds(1000);
        mTimer.Start();

        return Task.CompletedTask;
    }

    public Task DeactivatedAsync()
    {
        mTimer.Stop();

        return Task.CompletedTask;
    }


    private void _Refresh()
    {
        var now  = DateTime.Now;
        var date = DateOnly.FromDateTime(now);

        Text = now.ToLongTimeString();

        if (date != mLastDate)
        {
            ToolTip = now.ToLongDateString();

            mLastDate = date;
        }
    }
}
