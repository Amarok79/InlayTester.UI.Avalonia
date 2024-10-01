// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


public readonly struct Id : IEquatable<Id>
{
    private readonly String mValue;


    public Id()
    {
        mValue = String.Empty;
    }

    public Id(String value)
    {
        mValue = value;
    }

    public Id(Guid guid)
    {
        mValue = guid.ToString("N");
    }


    public static Id New()
    {
        return new Id(Guid.NewGuid());
    }


    public override String ToString()
    {
        return mValue;
    }


    public static implicit operator String(Id id)
    {
        return id.ToString();
    }


    public static implicit operator Id(String value)
    {
        return new Id(value);
    }

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
