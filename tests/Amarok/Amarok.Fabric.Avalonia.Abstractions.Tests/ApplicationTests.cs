// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric.Avalonia.Infrastructure;
using Moq;
using NCrunch.Framework;


namespace Amarok;


[TestFixture, Serial]
public abstract class ApplicationTests
{
    [SetUp]
    public void Setup()
    {
        ServiceProviderLocator.ClearCache();
        TestApp.ServiceProviderMock.Reset();
    }

    [TearDown]
    public void Cleanup()
    {
        ServiceProviderLocator.ClearCache();
        TestApp.ServiceProviderMock.Reset();
    }
}
