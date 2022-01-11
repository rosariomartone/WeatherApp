using System.Collections.Generic;

namespace WeatherAppFMW.Models
{
    public interface IForecast
    {
        string GetName();

        string GetRegion();

        string GetCountry();

        double GetLatitude();

        double GetLongitude();

        string GetTimeZone();

        string GetCurrentTime();

        List<Forecastday> GetForecasts();
    }
}