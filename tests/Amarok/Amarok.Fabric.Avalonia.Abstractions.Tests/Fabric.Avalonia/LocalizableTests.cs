// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Microsoft.Extensions.Localization;
using Moq;


namespace Amarok.Fabric.Avalonia;


[TestFixture]
public class LocalizableTests
{
    [Test]
    public void New_from_Default()
    {
        var s = default(Localizable);

        Check.That(s.ResourceKey).IsNull();
        Check.That(s.Args).IsNull();
        Check.That(s.ToString()).IsEqualTo("[]");

        var loc = new Mock<IStringLocalizer>(MockBehavior.Strict);
        var ls  = s.GetString(loc.Object);

        Check.That(ls).IsEqualTo("");
    }

    [Test]
    public void New_from_String()
    {
        var s = new Localizable("key");

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).IsEmpty();
        Check.That(s.ToString()).IsEqualTo("[key]");

        var loc = new Mock<IStringLocalizer>(MockBehavior.Strict);
        loc.Setup(x => x["key"]).Returns(new LocalizedString("key", "aaa"));

        var ls = s.GetString(loc.Object);

        Check.That(ls).IsEqualTo("aaa");
    }

    [Test]
    public void New_from_String_Arguments()
    {
        var s = new Localizable("key", 123, "bbb");

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).ContainsExactly(123, "bbb");
        Check.That(s.ToString()).IsEqualTo("[key]");

        var loc = new Mock<IStringLocalizer>(MockBehavior.Strict);
        loc.Setup(x => x["key", 123, "bbb"]).Returns(new LocalizedString("key", "aaa123bbb"));

        var ls = s.GetString(loc.Object);

        Check.That(ls).IsEqualTo("aaa123bbb");
    }


    [Test]
    public void New_from_String_ImplicitCast()
    {
        Localizable s = "key";

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).IsEmpty();
    }

    [Test]
    public void New_from_Tuple_ImplicitCast_String_Arg1()
    {
        Localizable s = ("key", 123);

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).ContainsExactly(123);
    }

    [Test]
    public void New_from_Tuple_ImplicitCast_String_Arg1_Arg2()
    {
        Localizable s = ("key", 123, "bbb");

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).ContainsExactly(123, "bbb");
    }

    [Test]
    public void New_from_Tuple_ImplicitCast_String_Arg1_Arg2_Arg3()
    {
        Localizable s = ("key", 123, "bbb", 12.3);

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).ContainsExactly(123, "bbb", 12.3);
    }

    [Test]
    public void New_from_Tuple_ImplicitCast_String_Arg1_Arg2_Arg3_Arg4()
    {
        Localizable s = ("key", 123, "bbb", 12.3, "c");

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).ContainsExactly(123, "bbb", 12.3, "c");
    }

    [Test]
    public void New_from_Tuple_ImplicitCast_String_Arg1_Arg2_Arg3_Arg4_Arg5()
    {
        Localizable s = ("key", 123, "bbb", 12.3, "c", 999);

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).ContainsExactly(123, "bbb", 12.3, "c", 999);
    }

    [Test]
    public void New_from_Tuple_ImplicitCast_String_Args()
    {
        Localizable s = ("key", [
            123,
            "bbb",
            12.3,
            "c",
            999,
        ]);

        Check.That(s.ResourceKey).IsEqualTo("key");
        Check.That(s.Args).ContainsExactly(123, "bbb", 12.3, "c", 999);
    }
}
