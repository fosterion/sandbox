using GrpcSandbox.Protos.Extensions;
using GrpcSandbox.Server.Services;

namespace GrpcSandbox.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.RegisterGrpc();

            var app = builder.Build();

            app.MapGrpcService<MarketService>();

            app.MapGet("/", () => "Woops, gRPC has no web interface");

            app.Run();
        }
    }
}