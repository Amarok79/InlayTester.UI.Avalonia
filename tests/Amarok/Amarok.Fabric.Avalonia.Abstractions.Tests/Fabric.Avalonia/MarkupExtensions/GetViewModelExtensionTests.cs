// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Avalonia.Headless.NUnit;
using Moq;
using NCrunch.Framework;


namespace Amarok.Fabric.Avalonia.MarkupExtensions;


[TestFixture, Serial]
public class GetViewModelExtensionTests : ApplicationTests
{
    [AvaloniaTest]
    public void ProvideValue_for_ContractKey()
    {
        var vf = new Mock<IViewFactory>(MockBehavior.Strict);

        TestApp.ServiceProviderMock.Setup(x => x.GetService(typeof(IViewFactory))).Returns(vf.Object);

        var vm = new DummyViewModel();

        vf.Setup(x => x.CreateViewModel("key")).Returns(vm);

        var e = new GetViewModelExtension("key");

        Check.That(e.ProvideValue()).IsEqualTo(vm);
    }

    [AvaloniaTest]
    public void ProvideValue_for_Type()
    {
        var vf = new Mock<IViewFactory>(MockBehavior.Strict);

        TestApp.ServiceProviderMock.Setup(x => x.GetService(typeof(IViewFactory))).Returns(vf.Object);

        var vm = new DummyViewModel();

        vf.Setup(x => x.CreateViewModel(typeof(DummyViewModel))).Returns(vm);

        var e = new GetViewModelExtension(typeof(DummyViewModel));

        Check.That(e.ProvideValue()).IsEqualTo(vm);
    }
}
