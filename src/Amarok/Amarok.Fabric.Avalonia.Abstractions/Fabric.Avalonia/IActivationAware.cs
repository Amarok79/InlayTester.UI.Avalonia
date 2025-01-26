// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.Fabric.Avalonia;


/// <summary>
///     An interface that View Model types should implement in order to respond to activation (load) and
///     deactivation (unload) events.
/// </summary>
public interface IActivationAware
{
    /// <summary>
    ///     Called when the View and its corresponding View Model are activated (loaded).
    /// </summary>
    Task ActivatedAsync();

    /// <summary>
    ///     Called when the View and its corresponding View Model are deactivated (unloaded).
    /// </summary>
    Task DeactivatedAsync();
}
