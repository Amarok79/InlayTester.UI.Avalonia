// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.ComponentModel.DataAnnotations;
using Amarok.Fabric.Avalonia;
using Amarok.Fabric.Avalonia.Infrastructure;
using CommunityToolkit.Diagnostics;


namespace InlayTester.UI;


public abstract class ValidationAttributeBase : ValidationAttribute
{
    protected Localizable? DefaultErrorMessage { get; init; }


    protected ValidationResult? Success()
    {
        return ValidationResult.Success;
    }

    protected ValidationResult Error()
    {
        Guard.IsNotNull(DefaultErrorMessage);
        return Error(DefaultErrorMessage.Value);
    }

    protected ValidationResult Error(Localizable errorMessage)
    {
        return new ValidationResult(errorMessage.GetString(ServiceProviderLocator.Localizer));
    }
}
