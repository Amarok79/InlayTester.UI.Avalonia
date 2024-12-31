// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using InlayTester.Domain;
using Microsoft.Extensions.Localization;


namespace InlayTester.UI.Pages.Users;


internal static partial class UserMappings
{
    public static UserListItemViewModel ToViewModel(
        this User user,
        UserListViewModel parent,
        IStringLocalizer localizer
    )
    {
        return new UserListItemViewModel {
            User         = user,
            Parent       = parent,
            Name         = user.Name,
            Roles        = user.RolesAsText,
            LastModified = localizer["users.label-modified", user.ModifiedAsText],
        };
    }
}
