// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Events;


namespace InlayTester.Domain;


public interface IUserSessionManager
{
    Event<None> CurrentChanged { get; }

    User? Current { get; }


    public String? GetCurrentUserName()
    {
        return Current?.Name;
    }


    Boolean Login(User user);

    void Logout();
}
