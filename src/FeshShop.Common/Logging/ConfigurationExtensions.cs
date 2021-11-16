namespace FeshShop.Common.Logging
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Serilog;
    using Serilog.Events;
    using System;

    public static partial class ConfigurationExtensions
    {
        public static IWebHostBuilder UseLogging(this IWebHostBuilder webHostBuilder, string applicationName = null)
            => webHostBuilder.UseSerilog((context, loggerConfiguration) => 
            {
                var serilogSettings = context
                    .Configuration
                    .GetSection(nameof(SerilogSettings))
                    .Get<SerilogSettings>();

                if (!Enum.TryParse<LogEventLevel>(serilogSettings.Level, true, out var level))
                    level = LogEventLevel.Information;

                loggerConfiguration
                    .Enrich.FromLogContext()
                    .MinimumLevel.Is(level)
                    .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName);

                if (serilogSettings.ConsoleEnabled)
                    loggerConfiguration.WriteTo.Console();
            });
    }
}
