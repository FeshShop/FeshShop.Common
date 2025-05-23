using Microsoft.Extensions.Hosting;

namespace FeshShop.Common.Logging;

using Abstraction;
using Settings;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;

public static class ConfigurationExtensions
{
    public static IServiceCollection AddLogger(this IServiceCollection services)
        => services.AddTransient<IMyLogger, MyLogger>();

    public static IHostBuilder UseLogging(this IHostBuilder webHostBuilder, string? applicationName = null)
        => webHostBuilder.UseSerilog((context, loggerConfiguration) => 
        {
            var serilogSettings = context
                .Configuration
                .GetOptions<SerilogSettings>();

            var seqSettings = context
                .Configuration
                .GetOptions<SeqSettings>();

            var appSettings = context
                .Configuration
                .GetOptions<AppSettings>();

            if (!Enum.TryParse<LogEventLevel>(serilogSettings.Level, true, out var level))
                level = LogEventLevel.Information;

            if (appSettings != null && string.IsNullOrWhiteSpace(appSettings.Name))
                applicationName = appSettings.Name;

            loggerConfiguration
                .Enrich.FromLogContext()
                .MinimumLevel.Is(level)
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("ApplicationName", applicationName);

            if (seqSettings != null && serilogSettings.ConsoleEnabled)
                loggerConfiguration.WriteTo.Console();

            if (seqSettings != null && seqSettings.Enabled)
                loggerConfiguration.WriteTo.Seq(seqSettings.Url, apiKey: seqSettings.Token);
        });
}