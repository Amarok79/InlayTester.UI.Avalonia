// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

// ReSharper disable InconsistentNaming

using Amarok.Fabric;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;


namespace InlayTester.UI;


/// <summary>
///     A view model base class with additional logging support.
/// </summary>
public abstract class ViewModelWithLogger : ObservableValidator
{
    private readonly Lazy<ILogger> mLogger;


    /// <summary>
    ///     The logger factory (injected)
    /// </summary>
    [Import]
    public ILoggerFactory? LoggerFactory { get; set; }

    /// <summary>
    ///     The logger for this view model
    /// </summary>
    public ILogger Logger => mLogger.Value;


    protected ViewModelWithLogger()
    {
        mLogger = new Lazy<ILogger>(_CreateLogger);
    }

    private ILogger _CreateLogger()
    {
        return LoggerFactory?.CreateLogger(GetType()) ?? NullLogger.Instance;
    }
}
