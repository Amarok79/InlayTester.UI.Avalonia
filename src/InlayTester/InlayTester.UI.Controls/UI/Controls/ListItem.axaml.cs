// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Material.Icons;


namespace InlayTester.UI.Controls;


public class ListItem : TemplatedControl
{
    #region Icon

    public static readonly StyledProperty<MaterialIconKind?> IconProperty =
        AvaloniaProperty.Register<ListItem, MaterialIconKind?>(nameof(Icon));

    public MaterialIconKind? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #endregion

    #region PrimaryText

    public static readonly DirectProperty<ListItem, String?> PrimaryTextProperty =
        AvaloniaProperty.RegisterDirect<ListItem, String?>(
            nameof(PrimaryText),
            o => o.PrimaryText,
            (o, v) => o.PrimaryText = v
        );

    private String? mPrimaryText;

    public String? PrimaryText
    {
        get => mPrimaryText;
        set => SetAndRaise(PrimaryTextProperty, ref mPrimaryText, value);
    }

    #endregion

    #region SecondaryText

    public static readonly DirectProperty<ListItem, String?> SecondaryTextProperty =
        AvaloniaProperty.RegisterDirect<ListItem, String?>(
            nameof(SecondaryText),
            o => o.SecondaryText,
            (o, v) => o.SecondaryText = v
        );

    private String? mSecondaryText;

    public String? SecondaryText
    {
        get => mSecondaryText;
        set => SetAndRaise(SecondaryTextProperty, ref mSecondaryText, value);
    }

    #endregion

    #region TertiaryText

    public static readonly DirectProperty<ListItem, String?> TertiaryTextProperty =
        AvaloniaProperty.RegisterDirect<ListItem, String?>(
            nameof(TertiaryText),
            o => o.TertiaryText,
            (o, v) => o.TertiaryText = v
        );

    private String? mTertiaryText;

    public String? TertiaryText
    {
        get => mTertiaryText;
        set => SetAndRaise(TertiaryTextProperty, ref mTertiaryText, value);
    }

    #endregion

    #region DeleteCommand

    public static readonly DirectProperty<ListItem, ICommand?> DeleteCommandProperty =
        AvaloniaProperty.RegisterDirect<ListItem, ICommand?>(
            nameof(DeleteCommand),
            o => o.DeleteCommand,
            (o, v) => o.DeleteCommand = v
        );

    private ICommand? mDeleteCommand;

    public ICommand? DeleteCommand
    {
        get => mDeleteCommand;
        set => SetAndRaise(DeleteCommandProperty, ref mDeleteCommand, value);
    }

    #endregion

    #region EditCommand

    public static readonly DirectProperty<ListItem, ICommand?> EditCommandProperty =
        AvaloniaProperty.RegisterDirect<ListItem, ICommand?>(
            nameof(EditCommand),
            o => o.EditCommand,
            (o, v) => o.EditCommand = v
        );

    private ICommand? mEditCommand;

    public ICommand? EditCommand
    {
        get => mEditCommand;
        set => SetAndRaise(EditCommandProperty, ref mEditCommand, value);
    }

    #endregion

    #region DeleteToolTip

    public static readonly StyledProperty<String?> DeleteToolTipProperty =
        AvaloniaProperty.Register<ListItem, String?>(nameof(DeleteToolTip));

    public String? DeleteToolTip
    {
        get => GetValue(DeleteToolTipProperty);
        set => SetValue(DeleteToolTipProperty, value);
    }

    #endregion

    #region EditToolTip

    public static readonly StyledProperty<String?> EditToolTipProperty =
        AvaloniaProperty.Register<ListItem, String?>(nameof(EditToolTip));

    public String? EditToolTip
    {
        get => GetValue(EditToolTipProperty);
        set => SetValue(EditToolTipProperty, value);
    }

    #endregion

    #region IsDeleteEnabled

    public static readonly StyledProperty<Boolean> IsDeleteEnabledProperty =
        AvaloniaProperty.Register<ListItem, Boolean>(nameof(IsDeleteEnabled), true);

    public Boolean IsDeleteEnabled
    {
        get => GetValue(IsDeleteEnabledProperty);
        set => SetValue(IsDeleteEnabledProperty, value);
    }

    #endregion

    #region IsEditEnabled

    public static readonly StyledProperty<Boolean> IsEditEnabledProperty =
        AvaloniaProperty.Register<ListItem, Boolean>(nameof(IsEditEnabled), true);

    public Boolean IsEditEnabled
    {
        get => GetValue(IsEditEnabledProperty);
        set => SetValue(IsEditEnabledProperty, value);
    }

    #endregion

    #region IsCommandAreaVisible

    public static readonly StyledProperty<Boolean> IsCommandAreaVisibleProperty =
        AvaloniaProperty.Register<ListItem, Boolean>(nameof(IsCommandAreaVisible), true);

    public Boolean IsCommandAreaVisible
    {
        get => GetValue(IsCommandAreaVisibleProperty);
        set => SetValue(IsCommandAreaVisibleProperty, value);
    }

    #endregion

    #region IsActive

    public static readonly StyledProperty<Boolean> IsActiveProperty =
        AvaloniaProperty.Register<ListItem, Boolean>(
            nameof(IsActive),
            defaultBindingMode: BindingMode.OneWayToSource
        );

    public Boolean IsActive
    {
        get => GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    #endregion

    #region Command

    public static readonly DirectProperty<ListItem, ICommand?> CommandProperty =
        AvaloniaProperty.RegisterDirect<ListItem, ICommand?>(
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
}
