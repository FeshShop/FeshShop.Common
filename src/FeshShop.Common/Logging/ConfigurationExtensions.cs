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

                var seqSettings = context
                    .Configuration
                    .GetSection(nameof(SeqSettings))
                    .Get<SeqSettings>();

                var appSettings = context
                    .Configuration
                    .GetSection(nameof(AppSettings))
                    .Get<AppSettings>();

                if (!Enum.TryParse<LogEventLevel>(serilogSettings.Level, true, out var level))
                    level = LogEventLevel.Information;

                var applicationName = string.Empty;

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
}
