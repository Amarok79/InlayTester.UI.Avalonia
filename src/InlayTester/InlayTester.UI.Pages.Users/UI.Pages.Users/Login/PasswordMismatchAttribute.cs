// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel.DataAnnotations;
using InlayTester.Domain;


namespace InlayTester.UI.Pages.Users;


public sealed class PasswordMismatchAttribute : ViewModelValidationAttributeBase<LoginOverlayViewModel>
{
    public PasswordMismatchAttribute()
    {
        DefaultErrorMessage = "login.error-password-mismatch";
    }


    protected override ValidationResult? IsValid(LoginOverlayViewModel vm, ValidationContext ctx)
    {
        if (vm.UserToValidate == null || vm.Password.IsNullOrWhitespace())
        {
            return Success();
        }

        return String.Equals(vm.Password, vm.UserToValidate.Password, StringComparison.Ordinal)
            ? Success()
            : Error();
    }
}
