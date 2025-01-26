// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


public sealed class RoleComparer : IComparer<Role>
{
    public static RoleComparer Default { get; } = new();


    public Int32 Compare(Role? x, Role? y)
    {
        if (ReferenceEquals(x, y))
        {
            return 0;
        }

        if (ReferenceEquals(null, y))
        {
            return 1;
        }

        if (ReferenceEquals(null, x))
        {
            return -1;
        }

        if (x.Id == Role.MachineOperatorId)
        {
            return -1;
        }

        if (y.Id == Role.MachineOperatorId)
        {
            return 1;
        }

        if (x.Id == Role.MachineSetterId)
        {
            return -1;
        }

        if (y.Id == Role.MachineSetterId)
        {
            return 1;
        }

        if (x.Id == Role.AdministratorId)
        {
            return -1;
        }

        if (y.Id == Role.AdministratorId)
        {
            return 1;
        }

        return String.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
}
