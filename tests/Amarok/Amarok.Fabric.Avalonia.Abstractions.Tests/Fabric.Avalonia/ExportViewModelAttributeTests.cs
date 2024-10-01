// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric.Avalonia.Infrastructure;
using DryIocAttributes;


namespace Amarok.Fabric.Avalonia;


[TestFixture]
public class ExportViewModelAttributeTests
{
    [ExportViewModel("key")]
    [ExportViewModel("key2")]
    public class DummyClass
    {
    }


    [Test]
    public void Usage()
    {
        var a = new ExportViewModelAttribute("abc");

        Check.That(a.ContractType).IsEqualTo(typeof(ViewModelRegistration));
        Check.That(a.ContractKey).IsEqualTo("abc");
        Check.That(a.ContractName).IsEqualTo("abc");
        Check.That(a.IfAlreadyExported).IsEqualTo(IfAlreadyExported.AppendNotKeyed);
    }
}
