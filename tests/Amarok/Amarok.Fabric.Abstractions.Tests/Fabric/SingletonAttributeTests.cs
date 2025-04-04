﻿// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using DryIocAttributes;


namespace Amarok.Fabric;


[TestFixture]
public class SingletonAttributeTests
{
    [Singleton]
    public class DummyClass
    {
    }


    [Test]
    public void Usage()
    {
        var a = new SingletonAttribute();

        Check.That(a.ReuseType).IsEqualTo(ReuseType.Singleton);
        Check.That(a.CustomReuseType).IsNull();
        Check.That(a.ScopeName).IsNull();
        Check.That(a.ScopeNames).IsNull();
    }
}
