// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using System.Windows.Input;
using Avalonia.Controls;


namespace InlayTester.UI.Shell;


public interface IShell
{
    INavigationService Navigation { get; }

    IMessageBoxManager MessageBox { get; }

    IOverlayManager Overlay { get; }


    public WindowIcon? WindowIcon { get; set; }

    public String? WindowTitle { get; set; }

    public String? PageTitle { get; set; }

    public ICommand? HomeCommand { get; set; }

    public Boolean IsHomeButtonVisible { get; set; }

    public Boolean IsUserStatusItemEnabled { get; set; }
}
