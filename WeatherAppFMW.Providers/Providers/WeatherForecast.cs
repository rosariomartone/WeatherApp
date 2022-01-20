using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAppFMW.Models;

namespace WeatherAppFMW.Providers.Providers
{
    /// <summary>
    /// Implementation of IForecastProvider for API.
    /// </summary>
    public class WeatherForecast : IForecastProvider
    {
        private string _apiKey = string.Empty;
        private string _forecastUrl = string.Empty;
        private HttpClient _client = null;

        /// <summary>
        /// Constructior for WeatherForecast.
        /// </summary>
        /// <param name="build"></param>
        public WeatherForecast(IConfiguration build, HttpClient client)
        {
            this._apiKey = build?.GetSection("API")?["Key"];
            this._forecastUrl = build?.GetSection("API")?["WeatherAPIUrl_Forecast"];
            this._client = client;
        }

        /// <summary>
        /// Retrieve a IForecast object using the city as input.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        public async Task<IForecast> GetForecastAsync(string city)
        {
            ForecastWeather forecast;
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri($"{ this._forecastUrl }?q={ city }");
            request.Method = HttpMethod.Get;
            request.Headers.Add("key", this._apiKey);
            HttpResponseMessage response = await this._client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;

            if (statusCode.Equals(HttpStatusCode.OK))
            {
                return JsonConvert.DeserializeObject<ForecastWeather>(responseString);
            }

            //Managing different API responses (403, 404, etc)

            return null;
        }
    }
}