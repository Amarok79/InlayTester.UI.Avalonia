// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


public sealed record class User(Id Id, String Name)
{
    public static readonly Int32 MaxNameLength = 50;

    public static readonly Int32 MaxPasswordLength = 50;

    public static readonly Int32 MaxNotesLength = 300;


    public String Password { get; init; } = String.Empty;

    public String Notes { get; init; } = String.Empty;

    public String ModifiedBy { get; init; } = String.Empty;

    public DateTime ModifiedOn { get; init; } = DateTime.Now;

    public IReadOnlySet<Role> Roles { get; init; } = new HashSet<Role>();


    public String RolesAsText => String.Join(", ", Roles.OrderBy(x => x, RoleComparer.Default).Select(x => x.Name));

    public String ModifiedText
        => ModifiedBy.IsNullOrWhitespace()
            ? ModifiedOn.ToString(CultureInfo.CurrentCulture)
            : $"{ModifiedBy}, {ModifiedOn.ToString(CultureInfo.CurrentCulture)}";


    public Boolean IsMachineOperator => Roles.Any(x => x.IsMachineOperator);

    public Boolean IsMachineSetter => Roles.Any(x => x.IsMachineSetter);

    public Boolean IsAdministrator => Roles.Any(x => x.IsAdministrator);

    public Boolean IsSupervisor => Id == SupervisorId;


    public static Id SupervisorId { get; } = new(new Guid("{F522BD39-DA07-41ad-A70F-04F4FDFC5A6D}"));


    public Boolean CanEdit()
    {
        return true;
    }

    public Boolean CanDelete()
    {
        return !IsSupervisor;
    }

    public Boolean Filter(String? text)
    {
        return FilterHelper.Filter(text, Name, RolesAsText, ModifiedText);
    }


    public override String ToString()
    {
        return Name;
    }
}
