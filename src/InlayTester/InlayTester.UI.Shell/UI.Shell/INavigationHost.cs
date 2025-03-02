﻿// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.UI.Shell;


internal interface INavigationHost
{
    public Object? Page { get; set; }

    public Boolean IsPageTransitionReversed { get; set; }
}
