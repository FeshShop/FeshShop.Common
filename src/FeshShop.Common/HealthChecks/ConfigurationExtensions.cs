namespace FeshShop.Common.HealthChecks
{
    using FeshShop.Common.Mongo;
    using global::HealthChecks.UI.Client;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddHealthChecker(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration
                .GetSection(nameof(MongoDbSettings))
                .Get<MongoDbSettings>();

            services
                .AddHealthChecks()
                .AddMongoDb(options.ConnectionString, options.Database, HealthStatus.Unhealthy);

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
}
