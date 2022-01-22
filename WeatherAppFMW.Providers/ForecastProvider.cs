using Microsoft.Extensions.Configuration;
using System.Net.Http;
using WeatherAppFMW.Providers.Providers;
using WeatherAppFMW.Services;

namespace WeatherAppFMW.Providers
{
    /// <summary>
    /// This class is a provider for forecast.
    /// </summary>
    public static class ForecastProvider
    {
        /// <summary>
        /// Retrieve a IForecastProvider using the provider type and the config passed as params.
        /// </summary>
        /// <param name="providerType">The provider type.</param>
        /// <param name="root">The root for the congif object.</param>
        /// <returns></returns>
        public static IForecastProvider GetProvider(
            string providerType, 
            IConfiguration root,
            ILoggerService loggerService)
        {
            switch(providerType)
            {
                case "API":
                    return new WeatherForecast(
                        loggerService,
                        root, 
                        new HttpClient());
                default:
                    return null;
            }
        }
    }
}