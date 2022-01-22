using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using System.Net.Http;
using WeatherAppFMW.Models;
using WeatherAppFMW.Providers.Providers;

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

            WeatherForecast forecast = new WeatherForecast(this._loggerService.Object, this._config.Object, client);
            IForecast _forecast = forecast.GetForecastAsync(city).Result;

            Assert.IsNotNull(_forecast);
            Assert.IsTrue(_forecast.GetCountry().Equals("United Kingdom"));
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

            WeatherForecast forecast = new WeatherForecast(this._loggerService.Object, this._config.Object, client);
            IForecast _forecast = forecast.GetForecastAsync(city).Result;

            Assert.IsNull(_forecast);
        }
    }
}
