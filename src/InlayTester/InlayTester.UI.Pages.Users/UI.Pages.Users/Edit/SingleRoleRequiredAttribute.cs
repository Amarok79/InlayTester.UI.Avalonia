// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel.DataAnnotations;


namespace InlayTester.UI.Pages.Users;


public sealed class SingleRoleRequiredAttribute : ViewModelValidationAttributeBase<UserEditViewModel>
{
    public SingleRoleRequiredAttribute()
    {
        DefaultErrorMessage = "users.validation-error-role-required";
    }


    protected override ValidationResult? IsValid(UserEditViewModel vm, ValidationContext ctx)
    {
        return vm is { MachineOperator: false, MachineSetter: false, Administrator: false }
            ? Error()
            : Success();
    }
}
