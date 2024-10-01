// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Headless.NUnit;
using Microsoft.Extensions.Localization;
using Moq;
using NCrunch.Framework;


namespace Amarok.Fabric.Avalonia.MarkupExtensions;


[TestFixture, Serial]
public class GetTextExtensionTests : ApplicationTests
{
    [AvaloniaTest]
    public void ProvideValue_for_ResourceKey()
    {
        var loc = new Mock<IStringLocalizer>(MockBehavior.Strict);

        TestApp.ServiceProviderMock.Setup(x => x.GetService(typeof(IStringLocalizer))).Returns(loc.Object);

        loc.Setup(x => x["key"]).Returns(new LocalizedString("key", "text"));

        var e = new GetTextExtension("key");

        Check.That(e.ProvideValue()).IsEqualTo("text");
    }
}
