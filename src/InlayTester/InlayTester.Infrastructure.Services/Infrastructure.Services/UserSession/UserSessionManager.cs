// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Events;
using Amarok.Fabric;
using InlayTester.Domain;


namespace InlayTester.Infrastructure.Services.UserSession;


[Export<IUserSessionManager>]
internal sealed class UserSessionManager : IUserSessionManager,
    IDisposable
{
    private readonly EventSource<None> mCurrentChangedSource = new();


    public Event<None> CurrentChanged => mCurrentChangedSource.Event;

    public User? Current { get; private set; }


    public Boolean Login(User user)
    {
        user = user with { Password = String.Empty };

        Current = user;

        mCurrentChangedSource.Invoke(None.Instance);

        return true;
    }

    public void Logout()
    {
        Current = null;

        mCurrentChangedSource.Invoke(None.Instance);
    }

    public void Dispose()
    {
        mCurrentChangedSource.Dispose();
    }
}
