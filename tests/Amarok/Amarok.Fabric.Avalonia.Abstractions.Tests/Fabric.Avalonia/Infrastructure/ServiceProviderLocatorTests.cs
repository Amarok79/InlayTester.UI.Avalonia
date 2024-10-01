// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Headless.NUnit;
using NCrunch.Framework;


namespace Amarok.Fabric.Avalonia.Infrastructure;


[TestFixture, Serial]
public class ServiceProviderLocatorTests : ApplicationTests
{
    [AvaloniaTest]
    public void Get()
    {
        var sp = ServiceProviderLocator.Get();

        Check.That(sp).IsNotNull();
    }

    [Test]
    public void Get_Failed()
    {
        Check.ThatCode(() => ServiceProviderLocator.Get()).Throws<InvalidOperationException>();
    }
}
