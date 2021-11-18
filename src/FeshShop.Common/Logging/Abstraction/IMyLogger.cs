namespace FeshShop.Common.Logging.Abstraction
{
    public interface IMyLogger
    {
        void Debug(string message);

        void Info(string message);

        void Warning(string message);

        void Error(string message);
    }
}
