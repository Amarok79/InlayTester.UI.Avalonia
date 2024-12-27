// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using CommunityToolkit.Diagnostics;
using InlayTester.Domain;


namespace InlayTester.UI.Pages.Users;


internal static partial class UserMappings
{
    public static User ToModel(this UserEditViewModel vm, String currentUserName)
    {
        Guard.IsNotNull(vm.Name);
        Guard.IsNotNull(vm.Password1);
        Guard.IsNotNull(vm.Password2);


        var roles = new HashSet<Role>();

        if (vm.MachineOperator)
        {
            roles.Add(new Role(Role.MachineOperatorId, String.Empty));
        }

        if (vm.MachineSetter)
        {
            roles.Add(new Role(Role.MachineSetterId, String.Empty));
        }

        if (vm.Administrator)
        {
            roles.Add(new Role(Role.AdministratorId, String.Empty));
        }

        var user = new User(Id.New(), vm.Name) {
            Password   = vm.Password1,
            Notes      = vm.Notes ?? String.Empty,
            ModifiedBy = currentUserName,
            ModifiedOn = DateTime.Now,
            Roles      = roles,
        };

        return user;
    }
}
