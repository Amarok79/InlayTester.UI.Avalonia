// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

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
    public partial String Text { get; set; } = String.Empty;

    [ObservableProperty]
    public partial String ToolTip { get; set; } = String.Empty;

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
