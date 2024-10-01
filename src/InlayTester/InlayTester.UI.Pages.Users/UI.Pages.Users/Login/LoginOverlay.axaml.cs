// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Controls;


namespace InlayTester.UI.Pages.Users;


public partial class LoginOverlay : UserControl
{
    public LoginOverlay()
    {
        InitializeComponent();


        UpdateIsEffectivelyEnabled();
    }
}
