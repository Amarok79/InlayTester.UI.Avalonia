// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


[TestFixture]
public class RoleTests
{
    [Test]
    public void MachineOperator()
    {
        var role = new Role(Role.MachineOperatorId, "operator");

        Check.That(role.Id).IsEqualTo(Role.MachineOperatorId);
        Check.That(role.Name).IsEqualTo("operator");
        Check.That(role.IsMachineOperator).IsTrue();
        Check.That(role.IsMachineSetter).IsFalse();
        Check.That(role.IsAdministrator).IsFalse();
        Check.That(role.ToString()).IsEqualTo("Role { Id = 1b59a2f7236847b3a0977643d514eddf, Name = operator }");
    }

    [Test]
    public void MachineSetter()
    {
        var role = new Role(Role.MachineSetterId, "setter");

        Check.That(role.Id).IsEqualTo(Role.MachineSetterId);
        Check.That(role.Name).IsEqualTo("setter");
        Check.That(role.IsMachineOperator).IsFalse();
        Check.That(role.IsMachineSetter).IsTrue();
        Check.That(role.IsAdministrator).IsFalse();
        Check.That(role.ToString()).IsEqualTo("Role { Id = 2a6ddeb3537147758df72598f8c8c8cf, Name = setter }");
    }

    [Test]
    public void Administrator()
    {
        var role = new Role(Role.AdministratorId, "administrator");

        Check.That(role.Id).IsEqualTo(Role.AdministratorId);
        Check.That(role.Name).IsEqualTo("administrator");
        Check.That(role.IsMachineOperator).IsFalse();
        Check.That(role.IsMachineSetter).IsFalse();
        Check.That(role.IsAdministrator).IsTrue();
        Check.That(role.ToString()).IsEqualTo("Role { Id = 3b38b2d8bf9949a9b96ddb69ed378d50, Name = administrator }");
    }
}
