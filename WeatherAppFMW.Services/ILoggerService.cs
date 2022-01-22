namespace WeatherAppFMW.Services
{
    public interface ILoggerService
    {
        void LogInfo(string info);

        void LogWarning(string warning);

        void LogError(string error);

        void LogFatal(string fatalMessage);
    }
}
