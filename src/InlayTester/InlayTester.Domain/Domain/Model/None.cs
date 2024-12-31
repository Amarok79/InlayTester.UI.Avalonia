// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


public readonly record struct None
{
    public static readonly None Instance = default;


    public override String ToString()
    {
        return "<None>";
    }
}
