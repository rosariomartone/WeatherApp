using Microsoft.Extensions.Configuration;
using System;
using WeatherAppFMW.Models;
using WeatherAppFMW.Providers.Providers;

namespace WeatherApp.Providers.Tests
{
    public class BaseTest
    {
        protected IConfigurationRoot _config = null;

        public BaseTest()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .Build();
        }
        public IForecast GetResult(string city)
        {
            WeatherForecast forecast = new WeatherForecast(_config);

            return forecast.GetForecastAsync(city).Result;
        }
    }
}