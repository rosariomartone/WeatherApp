using System;
using System.Collections.Generic;
using WeatherAppFMW.Models;

namespace WeatherAppFMW.Helpers
{
    public static class ForecastRange
    {
        public static List<Hour> GetForecastRange(Forecastday forecasts, int hour)
        {
            List<Hour> hours = new List<Hour>();
            int forCastSplit = 1;

            for (int i = hour; i <= 23; i++)
            {
                if (forCastSplit > 3)
                {
                    break;
                }

                hours.Add(forecasts.Hour[i]);

                forCastSplit++;
            }

            return hours;
        }
    }
}