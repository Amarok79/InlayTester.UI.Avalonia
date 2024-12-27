// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel.DataAnnotations;


namespace InlayTester.UI;


public abstract class ViewModelValidationAttributeBase<TViewModel> : ValidationAttributeBase
{
    protected sealed override ValidationResult? IsValid(Object? value, ValidationContext ctx)
    {
        if (ctx.ObjectInstance is TViewModel vm)
        {
            return IsValid(vm, ctx);
        }

        return Success();
    }

    protected virtual ValidationResult? IsValid(TViewModel vm, ValidationContext ctx)
    {
        return Success();
    }
}
