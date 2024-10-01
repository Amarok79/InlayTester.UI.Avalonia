// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using DryIocAttributes;


namespace Amarok.Fabric;


[TestFixture]
public class TransientAttributeTests
{
    [Transient]
    public class DummyClass
    {
    }


    [Test]
    public void Usage()
    {
        var a = new TransientAttribute();

        Check.That(a.ReuseType).IsEqualTo(ReuseType.Transient);
        Check.That(a.CustomReuseType).IsNull();
        Check.That(a.ScopeName).IsNull();
        Check.That(a.ScopeNames).IsNull();
    }
}
