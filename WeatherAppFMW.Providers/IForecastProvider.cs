using System.Threading.Tasks;
using WeatherAppFMW.Models;

namespace WeatherAppFMW.Providers
{
    public interface IForecastProvider
    {
        Task<IForecast> GetForecastAsync(string city);
    }
}