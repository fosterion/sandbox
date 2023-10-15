using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sandbox.Server.Services;

namespace Sandbox.Server;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddGrpc();

        var app = builder.Build();

        app.MapGrpcService<MarketService>();

        app.MapGet("/", () => "Woops, gRPC has no web interface");

        app.Run();
    }
}
