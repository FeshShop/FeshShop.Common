namespace FeshShop.Common.Authentication
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration) 
        {
            var options = configuration.GetOptions<JwtSettings>();

            services.AddSingleton(options);
            services.AddSingleton<IJwtHandler, JwtHandler>();

            return services;
        }
    }
}
