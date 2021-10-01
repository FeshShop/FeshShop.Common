﻿namespace FeshShop.Common.Swagger
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration
                .GetSection(nameof(SwaggerSettings))
                .Get<SwaggerSettings>();

            if (!options.Enabled)
            {
                return services;
            }

            return services.AddSwaggerGen();
        }

        public static IApplicationBuilder UseSwagger(this IApplicationBuilder builder)
        {
            var options = builder
                .ApplicationServices
                .GetRequiredService<IConfiguration>()
                .GetSection(nameof(SwaggerSettings))
                .Get<SwaggerSettings>();

            if (!options.Enabled)
            {
                return builder;
            }

            builder.UseSwagger(c => c.RouteTemplate = "swagger/{documentName}/swagger.json");

            return builder.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{options.Name}/swagger.json", options.Title));
        }
    }
}
