using NUnit.Framework;
using WeatherAppFMW.Models;

namespace WeatherApp.Providers.Tests
{
    public class Tests : BaseTest
    {
        [Test]
        [TestCase("London")]
        public void GetForecastAsync_RetrieveCountryInfo(string city)
        {
            IForecast forecast = GetResult(city);
            Assert.IsTrue(forecast.GetCountry().Equals("United Kingdom"));
        }

        [Test]
        [TestCase("unknown")]
        public void GetForecastAsync_FailRetrieveCountryInfo(string city)
        {
            IForecast forecast = GetResult(city);
            Assert.IsNull(forecast);
        }
    }
}