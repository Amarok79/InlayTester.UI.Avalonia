// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using NFluent.Helpers;


namespace InlayTester.Domain;


[TestFixture]
public class UserTests
{
    [Test]
    public void Defaults()
    {
        var su = new User(User.SupervisorId, "supervisor");

        Check.That(su.Id).IsEqualTo(User.SupervisorId);
        Check.That(su.Name).IsEqualTo("supervisor");
        Check.That(su.Password).IsEmpty();
        Check.That(su.ModifiedBy).IsEmpty();
        Check.That(su.ModifiedOn).IsCloseTo(DateTime.Now, new Duration(1, TimeUnit.Seconds));
        Check.That(su.Notes).IsEmpty();
        Check.That(su.Roles).IsEmpty();
        Check.That(su.IsMachineOperator).IsFalse();
        Check.That(su.IsMachineSetter).IsFalse();
        Check.That(su.IsAdministrator).IsFalse();
        Check.That(su.IsSupervisor).IsTrue();
        Check.That(su.ToString())
            .IsEqualTo("User { Id = f522bd39da0741ada70f04f4fdfc5a6d, Name = supervisor }");
    }

    [Test]
    public void Usage()
    {
        var now = new DateTime(2024, 12, 13, 11, 22, 33);

        var su = new User(User.SupervisorId, "supervisor") {
            Password   = "ppp",
            ModifiedBy = "aaa",
            ModifiedOn = now,
            Notes      = "nnn",
            Roles = new HashSet<Role>(
                [
                    new Role(Role.MachineOperatorId, "o"),
                    new Role(Role.MachineSetterId, "s"),
                    new Role(Role.AdministratorId, "a"),
                ]
            ) };

        Check.That(su.Id).IsEqualTo(User.SupervisorId);
        Check.That(su.Name).IsEqualTo("supervisor");
        Check.That(su.Password).IsEqualTo("ppp");
        Check.That(su.ModifiedBy).IsEqualTo("aaa");
        Check.That(su.ModifiedOn).IsEqualTo(now);
        Check.That(su.Notes).IsEqualTo("nnn");
        Check.That(su.Roles).HasSize(3);
        Check.That(su.IsMachineOperator).IsTrue();
        Check.That(su.IsMachineSetter).IsTrue();
        Check.That(su.IsAdministrator).IsTrue();
        Check.That(su.IsSupervisor).IsTrue();
    }

    [Test]
    public void RolesAsText_None()
    {
        var su = new User(User.SupervisorId, "supervisor");

        Check.That(su.RolesAsText).IsEmpty();
    }

    [Test]
    public void RolesAsText_Some()
    {
        var su = new User(User.SupervisorId, "supervisor") {
            Roles = new HashSet<Role>(
                [
                    new Role(Role.AdministratorId, "a"),
                    new Role(Role.MachineSetterId, "s"),
                    new Role(Role.MachineOperatorId, "o"),
                ]
            ),
        };

        Check.That(su.RolesAsText).IsEqualTo("o, s, a");
    }

    [Test, SetCulture("en-US")]
    public void ModifiedAsText_On()
    {
        var now = new DateTime(2024, 12, 13, 11, 22, 33);

        var su = new User(User.SupervisorId, "supervisor") {
            ModifiedOn = now,
        };

        Check.That(su.ModifiedAsText).IsEqualTo("12/13/2024 11:22:33 AM");
    }

    [Test, SetCulture("en-US")]
    public void ModifiedAsText_On_And_By()
    {
        var now = new DateTime(2024, 12, 13, 11, 22, 33);

        var su = new User(User.SupervisorId, "supervisor") {
            ModifiedBy = "aaa",
            ModifiedOn = now,
        };

        Check.That(su.ModifiedAsText).IsEqualTo("aaa, 12/13/2024 11:22:33 AM");
    }

    [Test]
    public void CanEdit()
    {
        var ok = new User("okay", "ok");
        var su = new User(User.SupervisorId, "supervisor");

        Check.That(ok.CanEdit()).IsTrue();
        Check.That(su.CanEdit()).IsTrue();
    }

    [Test]
    public void CanDelete()
    {
        var ok = new User("okay", "ok");
        var su = new User(User.SupervisorId, "supervisor");

        Check.That(ok.CanDelete()).IsTrue();
        Check.That(su.CanDelete()).IsFalse();
    }

    [Test]
    public void Filter_MostlyEmptyUser()
    {
        var us = new User("some-id", "aaa");

        Check.That(us.Filter(null)).IsTrue();
        Check.That(us.Filter("")).IsTrue();
        Check.That(us.Filter("a")).IsTrue();
        Check.That(us.Filter("b")).IsFalse();
    }

    [Test]
    public void Filter_MostlyDefinedUser()
    {
        var now = new DateTime(2024, 12, 13, 11, 22, 33);

        var us = new User("some-id", "aaa") {
            Password   = "ppp",
            ModifiedBy = "ccc",
            ModifiedOn = now,
            Notes      = "nnn",
            Roles = new HashSet<Role>(
                [
                    new Role(Role.MachineOperatorId, "operator"),
                    new Role(Role.MachineSetterId, "setter"),
                    new Role(Role.AdministratorId, "admin"),
                ]
            ),
        };

        Check.That(us.Filter(null)).IsTrue();
        Check.That(us.Filter("")).IsTrue();
        Check.That(us.Filter("a")).IsTrue();
        Check.That(us.Filter("aaa")).IsTrue();
        Check.That(us.Filter("aaaa")).IsFalse();
        Check.That(us.Filter("some")).IsFalse();
        Check.That(us.Filter("ppp")).IsFalse();
        Check.That(us.Filter("ccc")).IsTrue();
        Check.That(us.Filter("nnn")).IsFalse();
        Check.That(us.Filter("operator")).IsTrue();
        Check.That(us.Filter("setter")).IsTrue();
        Check.That(us.Filter("admin")).IsTrue();
        Check.That(us.Filter("etter")).IsTrue();
        Check.That(us.Filter("2024")).IsTrue();
    }
}
