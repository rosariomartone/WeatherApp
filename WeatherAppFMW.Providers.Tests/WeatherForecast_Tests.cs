using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherAppFMW.Models;

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

            Mock<IForecastProvider> _forecastProvider = new Mock<IForecastProvider>();
            _forecastProvider.Setup(x => x.GetForecastAsync(city))
                .ReturnsAsync(forecastWeather);

            IForecast forecast = GetResult(city, _forecastProvider);
            Assert.IsTrue(forecast.GetCountry().Equals("United Kingdom"));
        }

        /// <summary>
        /// Testing it is not returned the Country for the invalid city as input.
        /// </summary>
        /// <param name="city">The city as input.</param>
        [TestMethod]
        [DataRow("unknown")]
        public void GetForecastAsync_FailRetrieveCountryInfo(string city)
        {
            Mock<IForecastProvider> _forecastProvider = new Mock<IForecastProvider>();
            IForecast forecast = GetResult(city, _forecastProvider);
            Assert.IsNull(forecast);
        }
    }
}
