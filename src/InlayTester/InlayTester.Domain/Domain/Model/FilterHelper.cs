﻿// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


internal static class FilterHelper
{
    public static Boolean Filter(String text, params String[] properties)
    {
        text = text.Trim();

        return properties.Any(x => x.Contains(text, StringComparison.OrdinalIgnoreCase));
    }
}
