// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


public sealed record class Role(Id Id, String Name)
{
    public static Id MachineOperatorId { get; } = new(new Guid("{1B59A2F7-2368-47b3-A097-7643D514EDDF}"));

    public static Id MachineSetterId { get; } = new(new Guid("{2A6DDEB3-5371-4775-8DF7-2598F8C8C8CF}"));

    public static Id AdministratorId { get; } = new(new Guid("{3B38B2D8-BF99-49a9-B96D-DB69ED378D50}"));


    public Boolean IsMachineOperator => Id == MachineOperatorId;

    public Boolean IsMachineSetter => Id == MachineSetterId;

    public Boolean IsAdministrator => Id == AdministratorId;
}
