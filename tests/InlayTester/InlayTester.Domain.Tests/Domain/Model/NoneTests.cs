// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


[TestFixture]
public class NoneTests
{
    [Test]
    public void Usage()
    {
        Check.That(None.Instance.ToString()).IsEqualTo("<None>");
        Check.That(None.Instance).IsEqualTo(None.Instance);
    }
}
