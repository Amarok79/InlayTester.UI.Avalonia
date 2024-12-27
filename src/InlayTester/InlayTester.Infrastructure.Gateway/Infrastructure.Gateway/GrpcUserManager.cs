// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;
using InlayTester.Api.Contracts;
using InlayTester.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace InlayTester.Infrastructure.Gateway;


[Transient]
[Export<IUserManager>]
internal sealed class GrpcUserManager : IUserManager
{
    private readonly ILogger<GrpcUserManager> mLogger;
    private readonly ApiUserService.ApiUserServiceClient mClient;
    private readonly Int32 mSimulateSlowServerDelay;


    public GrpcUserManager(
        GrpcChannelProvider channelProvider,
        IConfiguration configuration,
        ILogger<GrpcUserManager> logger
    )
    {
        mLogger = logger;

        mSimulateSlowServerDelay = configuration.GetValue("gateway:simulate-slow-server-delay", 0);

        mClient = new ApiUserService.ApiUserServiceClient(channelProvider.Channel);
    }


    private async Task _SimulateSlowServer()
    {
        if (mSimulateSlowServerDelay > 0)
        {
            await Task.Delay(mSimulateSlowServerDelay);
        }
    }


    public async Task<Boolean> AddUserAsync(User user)
    {
        mLogger.LogDebug("gRPC: AddUserAsync({Id}, {Name})", user.Id, user.Name);

        await _SimulateSlowServer();

        var req = new AddUserRequest {
            User = new ApiUserWithPassword {
                User     = user.ToApi(),
                Password = user.Password,
            },
        };

        var rsp = await mClient.AddUserAsync(req);

        return rsp.Added;
    }

    public async Task<Boolean> DeleteAsync(Id id)
    {
        mLogger.LogDebug("gRPC: DeleteAsync({Id})", id);

        await _SimulateSlowServer();

        var req = new DeleteUserRequest {
            Id = id,
        };

        var rsp = await mClient.DeleteUserAsync(req);

        return rsp.Deleted;
    }

    public async Task<User?> GetUserAsync(Id id)
    {
        mLogger.LogDebug("gRPC: GetUserAsync({Id})", id);

        await _SimulateSlowServer();

        var req = new GetUserRequest {
            Id = id,
        };

        var rsp = await mClient.GetUserAsync(req);

        return rsp.OptionalCase == GetUserResponse.OptionalOneofCase.None ? null : rsp.User.ToModel();
    }

    public async Task<Boolean> UpdateUserAsync(User user)
    {
        mLogger.LogDebug("gRPC: UpdateUserAsync({Id}, {Name})", user.Id, user.Name);

        await _SimulateSlowServer();

        var req = new UpdateUserRequest {
            User = new ApiUserWithPassword {
                User     = user.ToApi(),
                Password = user.Password,
            },
        };

        var rsp = await mClient.UpdateUserAsync(req);

        return rsp.Updated;
    }

    public async Task<Boolean> ContainsUserNameAsync(String name)
    {
        mLogger.LogDebug("gRPC: ContainsUserNameAsync()");

        await _SimulateSlowServer();

        var req = new ContainsUserNameRequest {
            Name = name,
        };

        var rsp = await mClient.ContainsUserNameAsync(req);

        return rsp.Contains;
    }

    public async Task<IEnumerable<User>> QueryUsersAsync()
    {
        mLogger.LogDebug("gRPC: QueryUsersAsync()");

        await _SimulateSlowServer();

        var rsp = await mClient.QueryUsersAsync(new QueryUsersRequest());

        return rsp.Users.Select(x => x.ToModel());
    }

    public async Task<IEnumerable<Role>> QueryRolesAsync()
    {
        mLogger.LogDebug("gRPC: QueryRolesAsync()");

        await _SimulateSlowServer();

        var rsp = await mClient.QueryRolesAsync(new QueryRolesRequest());

        return rsp.Roles.Select(x => x.ToModel());
    }
}
