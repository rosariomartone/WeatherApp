using Microsoft.Extensions.Configuration;
using Moq;
using NSubstitute;
using WeatherAppFMW.Services.Interfaces;

namespace WeatherAppFMW.Providers.Tests
{
    /// <summary>
    /// Base class for Testing with Moq.
    /// </summary>
    public class BaseTest
    {
        protected Mock<IConfiguration> _config = null;
        protected ILoggerService _loggerService = null;
        protected IConfigurationSection _mockConfSection = null;

        /// <summary>
        /// Constructor for BaseTest.
        /// </summary>
        public BaseTest()
        {
            _config = new Mock<IConfiguration>();
            Mock<IConfigurationSection> mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "Key")]).Returns("0e859f7c894447c6a1d92912221102");
            mockConfSection.SetupGet(m => m[It.Is<string>(s => s == "WeatherAPIUrl_Forecast")]).Returns("http://api.weatherapi.com/v1/forecast.json");
            _config.Setup(a => a.GetSection(It.Is<string>(s => s == "API"))).Returns(mockConfSection.Object);

            _mockConfSection = Substitute.For<IConfigurationSection>();
            _loggerService = Substitute.For<ILoggerService>();
        }
    }
}