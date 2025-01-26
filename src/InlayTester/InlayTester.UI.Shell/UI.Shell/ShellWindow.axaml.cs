// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.VisualTree;


namespace InlayTester.UI.Shell;


public partial class ShellWindow : Window
{
    public ShellWindow()
    {
        InitializeComponent();
    }


    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        var shellView = this.FindDescendantOfType<ShellView>();

        if (shellView?.DataContext is ShellViewModel vm)
        {
            Bind(
                IconProperty,
                new Binding {
                    Source = vm,
                    Path   = nameof(ShellViewModel.WindowIcon),
                }
            );

            Bind(
                TitleProperty,
                new Binding {
                    Source = vm,
                    Path   = nameof(ShellViewModel.WindowTitle),
                }
            );
        }
    }
}
