using WeatherAppFMW.Providers.Enums;
using WeatherAppFMW.Services;
using WeatherAppFMW.Services.Interfaces;

namespace WeatherAppFMW.Providers
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