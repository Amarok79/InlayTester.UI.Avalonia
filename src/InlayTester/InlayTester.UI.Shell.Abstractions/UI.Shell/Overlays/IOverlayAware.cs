// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


public interface IOverlayAware
{
    IOverlayContext? Context { get; set; }
}
