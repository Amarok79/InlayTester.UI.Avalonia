// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.Media;
using Material.Icons;


namespace InlayTester.UI.Controls;


[TemplatePart("PART_Label", typeof(Label), IsRequired = true)]
[TemplatePart("PART_TextBox", typeof(TextBox), IsRequired = true)]
public class TextField : TemplatedControl
{
    #region Kind

    public static readonly DirectProperty<TextField, TextFieldKind> KindProperty =
        AvaloniaProperty.RegisterDirect<TextField, TextFieldKind>(
            nameof(Kind),
            o => o.Kind,
            (o, v) => o.Kind = v,
            defaultBindingMode: BindingMode.OneTime
        );

    private TextFieldKind mKind;

    public TextFieldKind Kind
    {
        get => mKind;
        set => SetAndRaise(KindProperty, ref mKind, value);
    }

    #endregion

    #region Icon

    public static readonly StyledProperty<MaterialIconKind?> IconProperty =
        AvaloniaProperty.Register<TextField, MaterialIconKind?>(nameof(Icon));

    public MaterialIconKind? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #endregion

    #region Label

    public static readonly StyledProperty<String?> LabelProperty =
        AvaloniaProperty.Register<TextField, String?>(nameof(Label));

    public String? Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    #endregion

    #region Placeholder

    public static readonly StyledProperty<String?> PlaceholderProperty =
        AvaloniaProperty.Register<TextField, String?>(nameof(Placeholder));

    public String? Placeholder
    {
        get => GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    #endregion

    #region Text

    public static readonly StyledProperty<String?> TextProperty =
        AvaloniaProperty.Register<TextField, String?>(
            nameof(Text),
            defaultBindingMode: BindingMode.TwoWay,
            enableDataValidation: true
        );

    public String? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #endregion

    #region IsReadOnly

    public static readonly StyledProperty<Boolean> IsReadOnlyProperty =
        AvaloniaProperty.Register<TextField, Boolean>(nameof(IsReadOnly));

    public Boolean IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    #endregion

    #region MaxLength

    public static readonly DirectProperty<TextField, Int32> MaxLengthProperty =
        AvaloniaProperty.RegisterDirect<TextField, Int32>(
            nameof(MaxLength),
            o => o.MaxLength,
            (o, v) => o.MaxLength = v,
            100
        );

    private Int32 mMaxLength;

    public Int32 MaxLength
    {
        get => mMaxLength;
        set => SetAndRaise(MaxLengthProperty, ref mMaxLength, value);
    }

    #endregion

    #region CanRevealPassword

    public static readonly StyledProperty<Boolean> CanRevealPasswordProperty =
        AvaloniaProperty.Register<TextField, Boolean>(nameof(CanRevealPassword), true);

    public Boolean CanRevealPassword
    {
        get => GetValue(CanRevealPasswordProperty);
        set => SetValue(CanRevealPasswordProperty, value);
    }

    #endregion


    private Label? mLabel;
    private TextBox? mTextBox;


    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        mLabel   = e.NameScope.Get<Label>("PART_Label");
        mTextBox = e.NameScope.Get<TextBox>("PART_TextBox");

        _UpdateKind(Kind);
    }

    protected override void UpdateDataValidation(
        AvaloniaProperty property,
        BindingValueType state,
        Exception? error
    )
    {
        if (property == TextProperty && mTextBox != null)
        {
            DataValidationErrors.SetError(mTextBox, error);
        }
    }


    private void _UpdateKind(TextFieldKind kind)
    {
        // only one-time binding supported right now

        if (kind == TextFieldKind.Text)
        {
            mTextBox!.Classes.Add("has-clear-button");
            mTextBox!.MinHeight                = 34;
            mTextBox!.VerticalContentAlignment = VerticalAlignment.Center;
        }
        else if (kind == TextFieldKind.Password)
        {
            if (CanRevealPassword)
            {
                mTextBox!.Classes.Add("has-reveal-password-button");
            }

            mTextBox!.PasswordChar             = '\x2022';
            mTextBox!.MinHeight                = 34;
            mTextBox!.VerticalContentAlignment = VerticalAlignment.Center;
        }
        else if (kind == TextFieldKind.MultiLine)
        {
            mTextBox!.MinLines      = 3;
            mTextBox!.TextWrapping  = TextWrapping.Wrap;
            mTextBox!.MaxHeight     = 76;
            mTextBox!.AcceptsReturn = true;
        }
    }
}
