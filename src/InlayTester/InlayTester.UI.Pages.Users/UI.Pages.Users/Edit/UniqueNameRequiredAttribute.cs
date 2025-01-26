// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel.DataAnnotations;


namespace InlayTester.UI.Pages.Users;


public sealed class UniqueNameRequiredAttribute : ViewModelValidationAttributeBase<UserEditViewModel>
{
    public UniqueNameRequiredAttribute()
    {
        DefaultErrorMessage = "users.validation-error-name-exists";
    }


    protected override ValidationResult? IsValid(UserEditViewModel vm, ValidationContext ctx)
    {
        return vm.HasUniqueName ? Success() : Error();
    }
}
