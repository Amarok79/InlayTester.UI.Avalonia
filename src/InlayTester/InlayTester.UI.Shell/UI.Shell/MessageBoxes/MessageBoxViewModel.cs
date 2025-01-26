// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using Amarok.Fabric.Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InlayTester.UI.Shell.Infrastructure;
using Material.Icons;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;


namespace InlayTester.UI.Shell;


[Export<IMessageBoxManager>]
[Export<MessageBoxViewModel>]
[View<MessageBox>]
public partial class MessageBoxViewModel : ObservableObject,
    IMessageBoxManager
{
    [Import]
    public required ILayerManager LayerManager { get; set; }

    [Import]
    public required IStringLocalizer Loc { get; set; }

    [Import]
    public required ILogger<MessageBoxViewModel> Logger { get; set; }

    [Import]
    public required ILoggerFactory LoggerFactory { get; set; }


    public Task ShowInfoAsync(
        Localizable title,
        Localizable message,
        Localizable accept,
        CancellationToken cancellationToken = default
    )
    {
        return ShowAsync(
            MessageBoxStyle.Info,
            title.GetString(Loc),
            message.GetString(Loc),
            acceptText: accept.GetString(Loc),
            cancelIsVisible: false,
            cancellationToken: cancellationToken
        );
    }

    public Task<MessageBoxResult> ShowConfirmationAsync(
        Localizable question,
        Localizable consequence,
        Localizable accept,
        Localizable cancel,
        CancellationToken cancellationToken = default
    )
    {
        return ShowAsync(
            MessageBoxStyle.Question,
            question.GetString(Loc),
            consequence.GetString(Loc),
            acceptText: accept.GetString(Loc),
            cancelText: cancel.GetString(Loc),
            cancelIsVisible: true,
            cancellationToken: cancellationToken
        );
    }


    public Task ShowErrorAsync(
        String errorCode,
        Exception exception,
        CancellationToken cancellationToken = default
    )
    {
        LoggerFactory.CreateLogger("App").LogError(exception, "ERROR: {ErrorCode}", errorCode);

        return ShowAsync(
            MessageBoxStyle.Error,
            Loc["msgbox-general-error-title"],
            Loc["msgbox-general-error-text", errorCode, exception.GetBaseException().Message],
            cancellationToken: cancellationToken
        );
    }


    public async Task<MessageBoxResult> ShowAsync(
        MessageBoxStyle style,
        String title,
        String text,
        MaterialIconKind? icon = null,
        Boolean? cancelIsVisible = null,
        String? acceptText = null,
        String? cancelText = null,
        CancellationToken cancellationToken = default
    )
    {
        var tcs = new TaskCompletionSource<MessageBoxResult>();

        CancellationTokenRegistration registration = default;

        if (cancellationToken.CanBeCanceled)
        {
            registration = cancellationToken.Register(() => tcs.TrySetResult(MessageBoxResult.None));
        }


        Icon                = mapIcon();
        Title               = title;
        Text                = text;
        AcceptText          = mapAcceptText();
        CancelText          = mapCancelText();
        IsCancelVisible     = mapIsCancelVisible();
        IsInfoStyle         = style is MessageBoxStyle.Info;
        IsQuestionStyle     = style is MessageBoxStyle.Question;
        IsWarningStyle      = style is MessageBoxStyle.Warning;
        IsErrorStyle        = style is MessageBoxStyle.Error;
        IsAccentColorStyle  = style is MessageBoxStyle.Info;
        IsWarningColorStyle = style is MessageBoxStyle.Question or MessageBoxStyle.Warning;
        IsDangerColorStyle  = style is MessageBoxStyle.Error;
        AcceptCommand       = new RelayCommand(() => tcs.TrySetResult(MessageBoxResult.Accept));
        CancelCommand       = new RelayCommand(() => tcs.TrySetResult(MessageBoxResult.Cancel));

        LayerManager.ShowMessageBox();
        IsOpen = true;

        Logger.LogInformation("Opened {Style} message box with title '{Title}'", style, title);


        var result = await tcs.Task;

        await registration.DisposeAsync();


        IsOpen = false;
        LayerManager.HideMessageBox();

        Logger.LogInformation(
            "Closed {Style} message box with title '{Title}' -> Result: {Result}",
            style,
            title,
            result
        );


        return result;


        MaterialIconKind mapIcon()
        {
            if (icon != null)
            {
                return icon.Value;
            }

            return style switch {
                MessageBoxStyle.Info     => MaterialIconKind.InfoCircleOutline,
                MessageBoxStyle.Question => MaterialIconKind.QuestionMarkCircleOutline,
                MessageBoxStyle.Warning  => MaterialIconKind.WarningOutline,
                MessageBoxStyle.Error    => MaterialIconKind.ErrorOutline,
                _                        => MaterialIconKind.Duck,
            };
        }

        String mapAcceptText()
        {
            if (acceptText != null)
            {
                return acceptText;
            }

            return style switch {
                MessageBoxStyle.Info     => Loc["label-ok"],
                MessageBoxStyle.Question => Loc["label-yes"],
                MessageBoxStyle.Warning  => Loc["label-ok"],
                MessageBoxStyle.Error    => Loc["label-ok"],
                _                        => Loc["label-ok"],
            };
        }

        String mapCancelText()
        {
            if (cancelText != null)
            {
                return cancelText;
            }

            return style switch {
                MessageBoxStyle.Info     => Loc["label-cancel"],
                MessageBoxStyle.Question => Loc["label-no"],
                MessageBoxStyle.Warning  => Loc["label-cancel"],
                MessageBoxStyle.Error    => Loc["label-cancel"],
                _                        => Loc["label-cancel"],
            };
        }

        Boolean mapIsCancelVisible()
        {
            if (cancelIsVisible != null)
            {
                return cancelIsVisible.Value;
            }

            return style switch {
                MessageBoxStyle.Info     => false,
                MessageBoxStyle.Question => true,
                MessageBoxStyle.Warning  => false,
                MessageBoxStyle.Error    => false,
                _                        => false,
            };
        }
    }
}
