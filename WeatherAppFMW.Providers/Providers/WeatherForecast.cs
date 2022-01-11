using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAppFMW.Models;

namespace WeatherAppFMW.Providers.Providers
{
    public class WeatherForecast : IForecastProvider
    {
        private string _apiKey = string.Empty;
        private string _forecastUrl = string.Empty;

        public WeatherForecast(IConfigurationRoot build)
        {
            _apiKey = build.GetSection("API").GetSection("Key").Value;
            _forecastUrl = build.GetSection("API").GetSection("WeatherAPIUrl_Forecast").Value;
        }

        public async Task<IForecast> GetForecastAsync(string city)
        {
            ForecastWeather forecast;
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri($"{ this._forecastUrl }?q={ city }");
            request.Method = HttpMethod.Get;
            request.Headers.Add("key", this._apiKey);
            HttpResponseMessage response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                try
                {
                    return JsonConvert.DeserializeObject<ForecastWeather>(responseString);
                }
                catch(Exception ex)
                {
                    string message = ex.StackTrace;
                }
            }

            //Managing different API responses (403, 404, etc)

            return null;
        }
    }
}