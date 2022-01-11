using WeatherApp.Models;

namespace WeatherApp.Providers
{
    public interface IForecastProvider
    {
        public Task<IForecast> GetForecastAsync(string city);
    }
}