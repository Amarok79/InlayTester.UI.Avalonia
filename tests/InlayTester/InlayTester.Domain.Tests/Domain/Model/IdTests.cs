// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


[TestFixture]
public class IdTests
{
    [Test]
    public void NewFromDefaultConstructor()
    {
        var id = new Id();

        Check.That(id.ToString()).IsEqualTo("");
    }

    [Test]
    public void NewFromConstructorString()
    {
        var id = new Id("aaa");

        Check.That(id.ToString()).IsEqualTo("aaa");
    }

    [Test]
    public void NewFromConstructorGuid()
    {
        var id = new Id(new Guid("942BA267-EE3C-46C7-B5FF-A266B327706F"));

        Check.That(id.ToString()).IsEqualTo("942ba267ee3c46c7b5ffa266b327706f");
    }

    [Test]
    public void New()
    {
        var id = Id.New();

        Check.That(id.ToString()).IsNotEmpty();
    }

    [Test]
    public void CastToString()
    {
        var id = new Id("aaa");

        Check.That((String)id).IsEqualTo("aaa");
    }

    [Test]
    public void CastFromString()
    {
        Id id = "aaa";

        Check.That(id.ToString()).IsEqualTo("aaa");
    }

    [Test]
    public void CastFromGuid()
    {
        Id id = new Guid("942BA267-EE3C-46C7-B5FF-A266B327706F");

        Check.That(id.ToString()).IsEqualTo("942ba267ee3c46c7b5ffa266b327706f");
    }

    [Test]
    public void Equality()
    {
        var a1 = new Id("aaa");
        var a2 = new Id("AAA");
        var b1 = new Id("bbb");

        Check.That(a1.GetHashCode()).IsEqualTo(a2.GetHashCode());
        Check.That(a1.GetHashCode()).IsNotEqualTo(b1.GetHashCode());

        Check.That(a1.Equals(a1)).IsTrue();
        Check.That(a1.Equals(a2)).IsTrue();
        Check.That(a1.Equals(b1)).IsFalse();

        Check.That(a1 == a2).IsTrue();
        Check.That(a1 == b1).IsFalse();

        Check.That(a1 != a2).IsFalse();
        Check.That(a1 != b1).IsTrue();
    }
}
