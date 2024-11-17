// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using InlayTester.Api.Contracts;
using InlayTester.Domain;


namespace InlayTester.Infrastructure.Gateway;


internal static class UserMappings
{
    public static User ToModel(this ApiUser user)
    {
        return new User(user.Id, user.Name) {
            Notes      = user.Notes,
            ModifiedBy = user.ModifiedBy,
            ModifiedOn = DateTime.Parse(user.ModifiedOn, CultureInfo.InvariantCulture),
            Roles      = user.Roles.Select(x => x.ToModel()).ToHashSet(),
        };
    }

    public static User ToModel(this ApiUserWithPassword user)
    {
        return new User(user.User.Id, user.User.Name) {
            Password   = user.Password,
            Notes      = user.User.Notes,
            ModifiedBy = user.User.ModifiedBy,
            ModifiedOn = DateTime.Parse(user.User.ModifiedOn, CultureInfo.InvariantCulture),
            Roles      = user.User.Roles.Select(x => x.ToModel()).ToHashSet(),
        };
    }

    public static Role ToModel(this ApiRole role)
    {
        return new Role(role.Id, role.Name);
    }


    public static ApiUser ToApi(this User user)
    {
        return new ApiUser {
            Id         = user.Id,
            Name       = user.Name,
            Notes      = user.Notes,
            ModifiedBy = user.ModifiedBy,
            ModifiedOn = user.ModifiedOn.ToString("O"),
            Roles = {
                user.Roles.Select(x => x.ToApi()),
            },
        };
    }

    public static ApiRole ToApi(this Role role)
    {
        return new ApiRole {
            Id   = role.Id,
            Name = role.Name,
        };
    }
}
