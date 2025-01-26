// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using DryIocAttributes;


namespace Amarok.Fabric;


[TestFixture]
public class ExportAttributeTests
{
    [Export<IServiceProvider>]
    [Export<DummyClass>]
    public class DummyClass : IServiceProvider
    {
        public Object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }


    [Test]
    public void Usage()
    {
        var a = new ExportAttribute<IServiceProvider>();

        Check.That(a.ContractType).IsEqualTo(typeof(IServiceProvider));
        Check.That(a.ContractKey).IsNull();
        Check.That(a.ContractName).IsNull();
        Check.That(a.IfAlreadyExported).IsEqualTo(IfAlreadyExported.AppendNotKeyed);
    }
}
