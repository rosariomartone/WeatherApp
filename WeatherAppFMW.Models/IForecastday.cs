using System.Collections.Generic;

namespace WeatherAppFMW.Models
{
    public interface IForecastday
    {
        List<Hour> Hour { get; }
    }
}