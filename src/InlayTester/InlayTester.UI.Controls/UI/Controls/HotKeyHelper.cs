// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.LogicalTree;


namespace InlayTester.UI.Controls;


public class HotKeyHelper : Control,
    ICommandSource
{
    #region HotKey

    public static readonly StyledProperty<KeyGesture?> HotKeyProperty =
        HotKeyManager.HotKeyProperty.AddOwner<HotKeyHelper>();

    public KeyGesture? HotKey
    {
        get => GetValue(HotKeyProperty);
        set => SetValue(HotKeyProperty, value);
    }

    #endregion

    #region Command

    public static readonly DirectProperty<HotKeyHelper, ICommand?> CommandProperty =
        AvaloniaProperty.RegisterDirect<HotKeyHelper, ICommand?>(
            nameof(Command),
            o => o.Command,
            (o, v) => o.Command = v
        );

    private ICommand? mCommand;

    public ICommand? Command
    {
        get => mCommand;
        set => SetAndRaise(CommandProperty, ref mCommand, value);
    }

    #endregion

    #region CommandParameter

    public static readonly DirectProperty<HotKeyHelper, Object?> CommandParameterProperty =
        AvaloniaProperty.RegisterDirect<HotKeyHelper, Object?>(
            nameof(CommandParameter),
            o => o.CommandParameter,
            (o, v) => o.CommandParameter = v
        );

    private Object? mCommandParameter;

    public Object? CommandParameter
    {
        get => mCommandParameter;
        set => SetAndRaise(CommandParameterProperty, ref mCommandParameter, value);
    }

    #endregion


    public HotKeyHelper()
    {
        IsVisible        = false;
        IsTabStop        = false;
        IsHitTestVisible = false;
        Focusable        = false;
    }

    public void CanExecuteChanged(Object sender, EventArgs e)
    {
    }

    protected override void OnDetachedFromLogicalTree(LogicalTreeAttachmentEventArgs e)
    {
        SetCurrentValue(HotKeyProperty, null);

        base.OnDetachedFromLogicalTree(e);
    }
}
