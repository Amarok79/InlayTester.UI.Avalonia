// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


public static class StringExtensions
{
    public static Boolean IsNullOrWhitespace(this String? value)
    {
        return String.IsNullOrWhiteSpace(value);
    }
}
