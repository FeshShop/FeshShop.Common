namespace FeshShop.Common.Authentication
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration) 
        {
            var options = configuration
                .GetSection(nameof(JwtSettings))
                .Get<JwtSettings>();

            services.AddSingleton(options);
            services.AddSingleton<IJwtHandler, JwtHandler>();

            return services;
        }

        public static long ToTimestamp(this DateTime dateTime)
        {
            var centuryBegin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expectedDate = dateTime.Subtract(new TimeSpan(centuryBegin.Ticks));

            return expectedDate.Ticks / 10000;
        }
    }
}
