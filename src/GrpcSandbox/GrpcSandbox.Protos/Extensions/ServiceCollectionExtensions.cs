using Microsoft.Extensions.DependencyInjection;

namespace GrpcSandbox.Protos.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterGrpc(this IServiceCollection services)
            => services.AddGrpc();
    }
}
