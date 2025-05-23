namespace FeshShop.Common.Logging.Abstraction;

using Serilog;

public class MyLogger(ILogger logger) : IMyLogger
{
    public void Debug(string message) => logger.Debug(message);

    public void Error(string message) => logger.Error(message);

    public void Info(string message) => logger.Information(message);

    public void Warning(string message) => logger.Warning(message);
}