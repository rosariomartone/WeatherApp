using Microsoft.Extensions.Configuration;
using WeatherApp.Providers.Providers;

namespace WeatherApp.Providers
{
    public static class ForecastProvider
    {
        public static IForecastProvider GetProvider(string providerType, IConfigurationRoot root)
        {
            switch(providerType)
            {
                case "API":
                    return new WeatherForecast(root);
                default:
                    return null;
            }
        }
    }
}