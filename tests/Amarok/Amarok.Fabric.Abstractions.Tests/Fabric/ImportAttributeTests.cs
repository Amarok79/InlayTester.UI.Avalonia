// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

#pragma warning disable CS0169 // Field is never used

namespace Amarok.Fabric;


[TestFixture]
public class ImportAttributeTests
{
    public class DummyClass
    {
        [Import]
        public required IServiceProvider ServiceProvider { get; set; }

        [Import]
        private readonly IServiceProvider mServiceProvider = null!;


        public DummyClass()
        {
            GC.KeepAlive(mServiceProvider);
        }
    }


    [Test]
    public void Usage()
    {
        var a = new ImportAttribute();

        Check.That(a.ContractType).IsNull();
        Check.That(a.ContractKey).IsNull();
        Check.That(a.ContractName).IsNull();
    }
}
