// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel.DataAnnotations;


namespace InlayTester.UI;


public sealed class FieldRequiredAttribute : ValidationAttributeBase
{
    public FieldRequiredAttribute()
    {
        DefaultErrorMessage = "validation-error-required";
    }


    protected override ValidationResult? IsValid(Object? value, ValidationContext validationContext)
    {
        return value switch {
            null                                       => Error(),
            String x when String.IsNullOrWhiteSpace(x) => Error(),
            _                                          => Success(),
        };
    }
}
