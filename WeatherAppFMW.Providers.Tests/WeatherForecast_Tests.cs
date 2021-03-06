using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NSubstitute;
using RichardSzalay.MockHttp;
using System.Net.Http;
using WeatherAppFMW.Models;
using WeatherAppFMW.Services;
using WeatherAppFMW.Services.Interfaces;

namespace WeatherAppFMW.Providers.Tests
{
    /// <summary>
    /// Testing the retrieving of the weather for a city as input.
    /// </summary>
    [TestClass]
    public class WeatherForecast_Tests : BaseTest
    {
        /// <summary>
        /// Testing it is returned the Country for the city as input.
        /// </summary>
        /// <param name="city">The city as input.</param>
        [TestMethod]
        [DataRow("London")]
        public void GetForecastAsync_RetrieveCountryInfo(string city)
        {
            ForecastWeather forecastWeather = new ForecastWeather()
            {
                Location = new Location()
                {
                    Country = "United Kingdom",
                }
            };

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://api.weatherapi.com/v1/*")
                    .Respond("application/json", JsonConvert.SerializeObject(forecastWeather));
            var client = new HttpClient(mockHttp);

            IForecastService forecast = new WeatherForecastService(this._loggerService, this._config.Object, client);
            IForecast _forecast = forecast.GetForecastAsync(city).Result;

            Assert.IsNotNull(_forecast);
            Assert.IsTrue(_forecast.GetCountry().Equals("United Kingdom"));
            this._loggerService.Received(1).LogInfo($"Response JSON was:");
            this._loggerService.DidNotReceive().LogError($"Error in making the call to the API.");
        }

        /// <summary>
        /// Testing it is not returned the Country for the invalid city as input.
        /// </summary>
        /// <param name="city">The city as input.</param>
        [TestMethod]
        [DataRow("unknown")]
        public void GetForecastAsync_FailRetrieveCountryInfo(string city)
        {
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://api.weatherapi.com/v1/*")
                    .Respond("application/json", string.Empty);
            var client = new HttpClient(mockHttp);

            IForecastService forecastService = new WeatherForecastService(this._loggerService, this._config.Object, client);
            IForecast _forecast = forecastService.GetForecastAsync(city).Result;

            Assert.IsNull(_forecast);
            this._loggerService.Received(1).LogError($"Error in making the call to the API.");
        }
    }
}
