using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherAppFMW.Helpers;
using WeatherAppFMW.Models;
using WeatherAppFMW.Providers;
using WeatherAppFMW.Providers.Interfaces;
using WeatherAppFMW.Services.Interfaces;

namespace WeatherAppFMW
{
    internal class Program
    {
        private static ILoggerService _loggerService = null;
        private static IForecastService _forecastService = null;

        public static void Main(string[] args)
        {
            string city;
            Console.Write("Enter name of the city: ");
            city = Console.ReadLine();

            while (!CheckInput.IsLocationInputValid(city))
            {
                Console.WriteLine("Please insert a valid location.");
                city = Console.ReadLine();
            }

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            string provider = config.GetSection("Provider").Value;
            _loggerService = LoggerProvider.GetLoggerService(Providers.Enums.EnumLogType.Serilog);
            _forecastService = ForecastProvider.GetService(provider, config, _loggerService);

            if (_forecastService != null)
            {
                IForecast weatherForecast = _forecastService.GetForecastAsync(city).Result;

                if (weatherForecast == null)
                {
                    string errorMessage = $"The city entered is not found: { city }";
                    Console.WriteLine(errorMessage);

                    _loggerService.LogWarning(errorMessage);
                }
                else
                {
                    _loggerService.LogWarning($"City: {city} has been found!");

                    Console.WriteLine("The city entered has been found: {0}", city);
                    Console.WriteLine("Name: {0}", weatherForecast.GetName());
                    Console.WriteLine("Region: {0}", weatherForecast.GetRegion());
                    Console.WriteLine("Country: {0}", weatherForecast.GetCountry());
                    Console.WriteLine("Lat: {0}", weatherForecast.GetLatitude());
                    Console.WriteLine("Lon: {0}", weatherForecast.GetLongitude());
                    Console.WriteLine("Time zone: {0}", weatherForecast.GetTimeZone());
                    Console.WriteLine("Current time: {0}", weatherForecast.GetCurrentTime());

                    Forecastday forecasts = weatherForecast.GetForecasts().FirstOrDefault();
                    List<Hour> hours = ForecastRange.GetForecastRange(forecasts, DateTime.Parse(weatherForecast.GetCurrentTime()).Hour);

                    foreach (Hour hour in hours)
                    {
                        Console.WriteLine("Forecast time: {0} is {1}", hour.Time, hour.Condition.Text);
                    }
                }

                Console.ReadLine();
            }
            else
            {
                string message = $"No providers found for: {provider}";
                Console.WriteLine(message);

                _loggerService.LogError(message);
            }
        }
    }
}