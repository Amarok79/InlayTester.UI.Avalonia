// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel.DataAnnotations;
using InlayTester.Domain;


namespace InlayTester.UI.Pages.Users;


public sealed class MatchingPasswordsRequiredAttribute : ViewModelValidationAttributeBase<UserEditViewModel>
{
    public MatchingPasswordsRequiredAttribute()
    {
        DefaultErrorMessage = "users.validation-error-password-mismatch";
    }


    protected override ValidationResult? IsValid(UserEditViewModel vm, ValidationContext ctx)
    {
        if (vm.Password1.IsNullOrWhitespace() || vm.Password2.IsNullOrWhitespace())
        {
            return Success();
        }

        return String.Equals(vm.Password1, vm.Password2, StringComparison.Ordinal) ? Success() : Error();
    }
}
