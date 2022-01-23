using System.Threading.Tasks;
using WeatherAppFMW.Models;
using WeatherAppFMW.Services;

namespace WeatherAppFMW.Providers.Interfaces
{
    public interface IForecastProvider
    {
        Task<IForecast> GetForecastAsync(string city);
    }
}