using WeatherAppFMW.Providers.Enums;
using WeatherAppFMW.Services;

namespace WeatherAppFMW.Providers.Providers
{
    public static class LoggerProvider
    {
        public static ILoggerService GetLoggerService(EnumLogType enumType)
        {
            switch (enumType)
            {
                case EnumLogType.Serilog:
                default:
                    return new LogService_Serilog();
            }
        }
    }
}