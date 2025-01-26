// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


[TestFixture]
public class RoleComparerTests
{
    [Test]
    public void Custom()
    {
        var c1 = new Role("custom-a", "a");
        var c2 = new Role("custom-z", "z");

        Check.That(RoleComparer.Default.Compare(c1, c1)).IsEqualTo(0);
        Check.That(RoleComparer.Default.Compare(c1, c2)).IsStrictlyLessThan(0);
        Check.That(RoleComparer.Default.Compare(c2, c2)).IsEqualTo(0);
    }

    [Test]
    public void OperatorLessThanSetter()
    {
        var o1 = new Role(Role.MachineOperatorId, "o");
        var o2 = new Role(Role.MachineOperatorId, "o");
        var s1 = new Role(Role.MachineSetterId, "s");
        var s2 = new Role(Role.MachineSetterId, "s");

        Check.That(RoleComparer.Default.Compare(null, o1)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(o1, o1)).IsEqualTo(0);
        Check.That(RoleComparer.Default.Compare(o1, o2)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(o1, s1)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(s1, o1)).IsEqualTo(+1);
        Check.That(RoleComparer.Default.Compare(s1, s1)).IsEqualTo(0);
        Check.That(RoleComparer.Default.Compare(s1, s2)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(o1, null)).IsEqualTo(+1);
    }

    [Test]
    public void OperatorLessThanAdministrator()
    {
        var o = new Role(Role.MachineOperatorId, "o");
        var a = new Role(Role.AdministratorId, "a");

        Check.That(RoleComparer.Default.Compare(null, o)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(o, o)).IsEqualTo(0);
        Check.That(RoleComparer.Default.Compare(o, a)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(a, o)).IsEqualTo(+1);
        Check.That(RoleComparer.Default.Compare(a, a)).IsEqualTo(0);
        Check.That(RoleComparer.Default.Compare(a, null)).IsEqualTo(+1);
    }

    [Test]
    public void SetterLessThanAdministrator()
    {
        var s1 = new Role(Role.MachineSetterId, "s");
        var s2 = new Role(Role.MachineSetterId, "s");
        var a1 = new Role(Role.AdministratorId, "a");
        var a2 = new Role(Role.AdministratorId, "a");

        Check.That(RoleComparer.Default.Compare(null, s1)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(s1, s1)).IsEqualTo(0);
        Check.That(RoleComparer.Default.Compare(s1, s2)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(s1, a1)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(a1, s1)).IsEqualTo(+1);
        Check.That(RoleComparer.Default.Compare(a1, a1)).IsEqualTo(0);
        Check.That(RoleComparer.Default.Compare(a1, a2)).IsEqualTo(-1);
        Check.That(RoleComparer.Default.Compare(a1, null)).IsEqualTo(+1);
    }
}
