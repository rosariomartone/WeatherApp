using Serilog;
using Serilog.Events;

namespace WeatherAppFMW.Services
{
    public class LogService_Serilog : ILoggerService
    {
        public LogService_Serilog()
        {
            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .MinimumLevel.Override("WeatherAppFMW", LogEventLevel.Information)
                    .WriteTo.File("Logs/WeatherAppFMW.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: null)
                    .CreateLogger();
        }

        public void LogError(string error)
        {
            Log.Error(error);
        }

        public void LogFatal(string fatalMessage)
        {
            Log.Fatal(fatalMessage);
        }

        public void LogInfo(string info)
        {
            Log.Information(info);
        }

        public void LogWarning(string warning)
        {
            Log.Warning(warning);
        }
    }
}