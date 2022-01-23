using Microsoft.Extensions.Configuration;
using System.Net.Http;
using WeatherAppFMW.Services;
using WeatherAppFMW.Services.Interfaces;

namespace WeatherAppFMW.Providers
{
    /// <summary>
    /// This class is a provider for forecast.
    /// </summary>
    public static class ForecastProvider
    {
        /// <summary>
        /// Retrieve a IForecastService using the provider type and the config passed as params.
        /// </summary>
        /// <param name="providerType">The provider type.</param>
        /// <param name="root">The root for the congif object.</param>
        /// <returns></returns>
        public static IForecastService GetService(
            string providerType,
            IConfiguration root,
            ILoggerService loggerService)
        {
            switch (providerType)
            {
                case "API":
                    return new WeatherForecastService(
                        loggerService,
                        root,
                        new HttpClient());
                default:
                    return null;
            }
        }
    }
}