// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


/// <summary>
///     Represents an identifier.
/// </summary>
public readonly struct Id : IEquatable<Id>
{
    private readonly String mValue;


    /// <summary>
    ///     Initializes an empty identifier.
    /// </summary>
    public Id()
    {
        mValue = String.Empty;
    }

    /// <summary>
    ///     Initializes an identifier from the given string.
    /// </summary>
    public Id(String value)
    {
        mValue = value;
    }

    /// <summary>
    ///     Initializes an identifier from the given guid.
    /// </summary>
    public Id(Guid guid)
    {
        mValue = guid.ToString("N");
    }


    /// <summary>
    ///     Initializes a random identifier.
    /// </summary>
    public static Id New()
    {
        return new Id(Guid.NewGuid());
    }



    /// <summary>
    ///     Returns the string representation.
    /// </summary>
    public override String ToString()
    {
        return mValue;
    }


    public static implicit operator String(Id id)
    {
        return id.ToString();
    }


    /// <summary>
    ///     Implicit cast from String
    /// </summary>
    public static implicit operator Id(String value)
    {
        return new Id(value);
    }

    /// <summary>
    ///     Implicit cast from Guid
    /// </summary>
    public static implicit operator Id(Guid value)
    {
        return new Id(value);
    }


    public Boolean Equals(Id other)
    {
        return String.Equals(mValue, other.mValue, StringComparison.OrdinalIgnoreCase);
    }

    public override Boolean Equals(Object? obj)
    {
        return obj is Id other && Equals(other);
    }

    public override Int32 GetHashCode()
    {
        return StringComparer.OrdinalIgnoreCase.GetHashCode(mValue);
    }

    public static Boolean operator ==(Id left, Id right)
    {
        return left.Equals(right);
    }

    public static Boolean operator !=(Id left, Id right)
    {
        return !left.Equals(right);
    }
}
