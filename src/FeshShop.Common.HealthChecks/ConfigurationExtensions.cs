namespace FeshShop.Common.HealthChecks;

using Mongo;
using global::HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddHealthChecker(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<MongoDbSettings>();

        services
            .AddHealthChecks()
            .AddMongoDb();

        return services;
    }

    public static void MapHealthCheckPath(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}