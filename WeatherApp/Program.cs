using Microsoft.Extensions.Configuration;
using WeatherApp.Helpers;
using WeatherApp.Models;
using WeatherApp.Providers;

string city;
Console.Write("Enter name of the city: ");
city = Console.ReadLine();

while (!CheckInput.IsLocationInputValid(city))
{
    Console.WriteLine("Please insert a valid location.");
    city = Console.ReadLine();
}

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", false, true)
    .Build();

string provider = config.GetSection("Provider").Value;

IForecastProvider forecastProvider = ForecastProvider.GetProvider(provider, config);

if(forecastProvider!= null)
{
    IForecast weatherForecast = await forecastProvider.GetForecastAsync(city);

    if (weatherForecast == null)
    {
        Console.WriteLine("The city entered is not found: {0}", city);
    }
    else
    {
        Console.WriteLine("The city entered has been found: {0}", city);
        Console.WriteLine("Name: {0}", weatherForecast.GetName());
        Console.WriteLine("Region: {0}", weatherForecast.GetRegion());
        Console.WriteLine("Country: {0}", weatherForecast.GetCountry());
        Console.WriteLine("Lat: {0}", weatherForecast.GetLatitude());
        Console.WriteLine("Lon: {0}", weatherForecast.GetLongitude());
        Console.WriteLine("Time zone: {0}", weatherForecast.GetTimeZone());
        Console.WriteLine("Current time: {0}", weatherForecast.GetCurrentTime());
    }
}
else
{
    Console.WriteLine("No providers found for: {0}", provider);
}