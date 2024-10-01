// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell.Infrastructure;


public interface ILayerManager
{
    Boolean IsBaseLayerEnabled { get; }

    Boolean IsMessageBoxLayerEnabled { get; }

    Boolean IsOverlayLayerEnabled { get; }


    void ShowMessageBox();

    void HideMessageBox();

    void ShowOverlay();

    void HideOverlay();
}
