using System.Threading.Tasks;
using WeatherAppFMW.Models;
using WeatherAppFMW.Services;

namespace WeatherAppFMW.Services.Interfaces
{
    public interface IForecastService
    {
        Task<IForecast> GetForecastAsync(string city);
    }
}