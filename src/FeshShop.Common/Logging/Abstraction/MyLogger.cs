namespace FeshShop.Common.Logging.Abstraction
{
    using Serilog;

    public class MyLogger : IMyLogger
    {
        private readonly ILogger logger;

        public MyLogger(ILogger logger) => this.logger = logger;

        public void Debug(string message) => this.logger.Debug(message);

        public void Error(string message) => this.logger.Error(message);

        public void Info(string message) => this.logger.Information(message);

        public void Warning(string message) => this.logger.Warning(message);
    }
}
