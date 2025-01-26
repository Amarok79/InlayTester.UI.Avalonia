// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.Fabric;


[TestFixture]
public class InheritedExportAttributeTests
{
    [Test]
    public void Usage()
    {
        var a = new InheritedExportAttribute<IServiceProvider>();

        Check.That(a.ContractType).IsEqualTo(typeof(IServiceProvider));
        Check.That(a.ContractName).IsNull();
    }
}
