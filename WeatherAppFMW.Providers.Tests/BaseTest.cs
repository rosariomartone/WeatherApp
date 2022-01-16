using Microsoft.Extensions.Configuration;
using Moq;
using WeatherAppFMW.Models;
using WeatherAppFMW.Providers.Providers;

namespace WeatherAppFMW.Providers.Tests
{
    /// <summary>
    /// Base class for Testing with Moq.
    /// </summary>
    public class BaseTest
    {
        protected Mock<IConfiguration> _config = null;

        /// <summary>
        /// Constructor for BaseTest.
        /// </summary>
        public BaseTest()
        {
            _config = new Mock<IConfiguration>();
            Mock<IConfigurationSection> mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "Key")]).Returns("0e859f7c894447c6a1d92912221101");
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "WeatherAPIUrl_Forecast")]).Returns("http://api.weatherapi.com/v1/forecast.json");
            _config.Setup(a => a.GetSection(It.Is<string>(s => s == "API"))).Returns(mockConfSection.Object);
        }

        /// <summary>
        /// Returns a IForecast for a city as input.
        /// </summary>
        /// <param name="city">The city as input for the search.</param>
        /// <returns></returns>
        public IForecast GetResult(string city)
        {
            WeatherForecast forecast = new WeatherForecast(_config.Object);

            return forecast.GetForecastAsync(city).Result;
        }
    }
}