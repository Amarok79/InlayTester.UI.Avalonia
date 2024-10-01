// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;
using InlayTester.UI.Shell;


namespace InlayTester.UI.Pages.Users;


[Transient]
internal sealed class UsersPageProvider : PageProviderBase
{
    protected override IEnumerable<PageDescriptor> OnGetPages()
    {
        yield return PageDescriptor.For<UserListViewModel>(UserPages.List);
        yield return PageDescriptor.For<UserEditViewModel>(UserPages.Edit);
    }
}
