// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Metadata;
using Material.Icons;


namespace InlayTester.UI.Controls;


[TemplatePart("PART_Label", typeof(Label), IsRequired = true)]
[TemplatePart("PART_Content", typeof(ContentPresenter), IsRequired = true)]
public class Field : TemplatedControl
{
    #region Icon

    public static readonly StyledProperty<MaterialIconKind?> IconProperty =
        AvaloniaProperty.Register<Field, MaterialIconKind?>(nameof(Icon));

    public MaterialIconKind? Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #endregion

    #region Label

    public static readonly StyledProperty<String?> LabelProperty =
        AvaloniaProperty.Register<Field, String?>(nameof(Label));

    public String? Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    #endregion

    #region Content

    public static readonly DirectProperty<Field, Object?> ContentProperty =
        AvaloniaProperty.RegisterDirect<Field, Object?>(
            nameof(Content),
            o => o.Content,
            (o, v) => o.Content = v
        );

    private Object? mContent;

    [Content]
    public Object? Content
    {
        get => mContent;
        set => SetAndRaise(ContentProperty, ref mContent, value);
    }

    #endregion

    #region Errors

    public static readonly DirectProperty<Field, Object?> ErrorsProperty =
        AvaloniaProperty.RegisterDirect<Field, Object?>(
            nameof(Errors),
            o => o.Errors,
            (o, v) => o.Errors = v,
            enableDataValidation: true
        );

    private Object? mErrors;

    public Object? Errors
    {
        get => mErrors;
        set => SetAndRaise(ErrorsProperty, ref mErrors, value);
    }

    #endregion


    protected override void UpdateDataValidation(
        AvaloniaProperty property,
        BindingValueType state,
        Exception? error
    )
    {
        if (property == ErrorsProperty)
        {
            DataValidationErrors.SetError(this, error);
        }
    }
}
