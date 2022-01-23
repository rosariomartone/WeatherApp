using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAppFMW.Models;
using WeatherAppFMW.Services;
using WeatherAppFMW.Services.Interfaces;

namespace WeatherAppFMW.Services
{
    /// <summary>
    /// Implementation of IForecastProvider for API.
    /// </summary>
    public class WeatherForecastService : IForecastService
    {
        private string _apiKey = string.Empty;
        private string _forecastUrl = string.Empty;
        private HttpClient _client = null;
        private ILoggerService _loggerService = null;

        /// <summary>
        /// Constructior for WeatherForecast.
        /// </summary>
        /// <param name="build"></param>
        public WeatherForecastService(
            ILoggerService loggerService, 
            IConfiguration build, 
            HttpClient client)
        {
            this._apiKey = build?.GetSection("API")?["Key"];
            this._forecastUrl = build?.GetSection("API")?["WeatherAPIUrl_Forecast"];
            this._client = client;
            this._loggerService = loggerService;
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

            this._loggerService.LogInfo($"Calling {request.Method} API: {request.RequestUri}");

            HttpResponseMessage response = await this._client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;

            this._loggerService.LogInfo($"Response was {statusCode.ToString()}.");

            if (statusCode.Equals(HttpStatusCode.OK) &&
                !string.IsNullOrEmpty(responseString))
            {
                this._loggerService.LogInfo($"Response JSON was:");
                this._loggerService.LogInfo($"{responseString}");

                return JsonConvert.DeserializeObject<ForecastWeather>(responseString);
            }
            else
            {
                this._loggerService.LogError($"Error in making the call to the API.");
            }

            return null;
        }
    }
}