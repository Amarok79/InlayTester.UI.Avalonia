// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

namespace InlayTester.Domain;


public interface IUserManager
{
    Task<Boolean> AddUserAsync(User user);

    Task<Boolean> DeleteAsync(Id id);

    Task<User?> GetUserAsync(Id id);

    Task<Boolean> UpdateUserAsync(User user);

    Task<Boolean> ContainsUserNameAsync(String name);

    Task<IEnumerable<User>> QueryUsersAsync();

    Task<IEnumerable<Role>> QueryRolesAsync();
}
