using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WeatherAppFMW.Models;

namespace WeatherAppFMW.Providers.Tests
{
    [TestClass]
    public class WeatherForecast_Tests : BaseTest
    {
        [TestMethod]
        [DataRow("London")]
        public void GetForecastAsync_RetrieveCountryInfo(string city)
        {
            IForecast forecast = GetResult(city);
            Assert.IsTrue(forecast.GetCountry().Equals("United Kingdom"));
        }

        [TestMethod]
        [DataRow("unknown")]
        public void GetForecastAsync_FailRetrieveCountryInfo(string city)
        {
            IForecast forecast = GetResult(city);
            Assert.IsNull(forecast);
        }
    }
}
