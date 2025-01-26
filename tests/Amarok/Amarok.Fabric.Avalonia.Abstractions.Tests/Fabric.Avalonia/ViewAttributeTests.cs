// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.Fabric.Avalonia;


[TestFixture]
public class ViewAttributeTests
{
    [Test]
    public void New_NonGeneric_with_Control()
    {
        var a = new ViewAttribute(typeof(DummyView));

        Check.That(a.ViewType).IsEqualTo(typeof(DummyView));
    }

    [Test]
    public void New_NonGeneric_with_NonControl()
    {
        Check.ThatCode(() => new ViewAttribute(typeof(String))).Throws<ArgumentException>();
    }


    [Test]
    public void New_Generic_with_Control()
    {
        var a = new ViewAttribute<DummyView>();

        Check.That(a.ViewType).IsEqualTo(typeof(DummyView));
    }
}
