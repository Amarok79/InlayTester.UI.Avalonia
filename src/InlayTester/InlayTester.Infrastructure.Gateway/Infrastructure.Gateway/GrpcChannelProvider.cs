// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using Amarok.Fabric;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace InlayTester.Infrastructure.Gateway;


[Export<GrpcChannelProvider>]
internal sealed class GrpcChannelProvider
{
    private readonly ILogger<GrpcChannelProvider> mLogger;
    private readonly Lazy<GrpcChannel> mChannel;


    public GrpcChannel Channel => mChannel.Value;


    public GrpcChannelProvider(IConfiguration configuration, ILogger<GrpcChannelProvider> logger)
    {
        mLogger  = logger;
        mChannel = new Lazy<GrpcChannel>(() => _CreateChannel(configuration));
    }


    private GrpcChannel _CreateChannel(IConfiguration configuration)
    {
        var uri = configuration.GetValue("ServerUri", "http://localhost:9999")!;

        var channel = GrpcChannel.ForAddress(
            uri,
            new GrpcChannelOptions {
                Credentials = ChannelCredentials.Insecure,
            }
        );

        mLogger.LogDebug("Created gRPC channel to {Uri}", uri);

        return channel;
    }
}
