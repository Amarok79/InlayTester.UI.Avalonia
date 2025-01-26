// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric.Avalonia;
using Material.Icons;


namespace InlayTester.UI.Shell;


public interface IMessageBoxManager
{
    Task ShowInfoAsync(
        Localizable title,
        Localizable message,
        Localizable accept,
        CancellationToken cancellationToken = default
    );

    Task<MessageBoxResult> ShowConfirmationAsync(
        Localizable question,
        Localizable consequence,
        Localizable accept,
        Localizable cancel,
        CancellationToken cancellationToken = default
    );

    Task ShowErrorAsync(String errorCode, Exception exception, CancellationToken cancellationToken = default);

    Task<MessageBoxResult> ShowAsync(
        MessageBoxStyle style,
        String title,
        String text,
        MaterialIconKind? icon = null,
        Boolean? cancelIsVisible = null,
        String? acceptText = null,
        String? cancelText = null,
        CancellationToken cancellationToken = default
    );
}
