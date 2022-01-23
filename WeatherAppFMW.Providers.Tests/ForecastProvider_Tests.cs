using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAppFMW.Services.Interfaces;

namespace WeatherAppFMW.Providers.Tests
{
    /// <summary>
    /// Testing the retrieving of the provider for a provider type as input.
    /// </summary>
    [TestClass]
    public class ForecastProvider_Tests : BaseTest
    {
        /// <summary>
        /// Testing the provider is correctly returned when the provider is valid.
        /// </summary>
        /// <param name="providerType"></param>
        [TestMethod]
        [DataRow("API")]
        public void GetService_RetrieveProvider(string providerType)
        {
            IForecastService forecastService = ForecastProvider.GetService(providerType, _config.Object, _loggerService.Object);

            Assert.IsNotNull(forecastService);
        }

        /// <summary>
        /// Testing the provider is correctly not returned when the provider is invalid.
        /// </summary>
        /// <param name="providerType"></param>
        [TestMethod]
        [DataRow("MSSQL")]
        public void GetProvider_FailingRetrieveProvider(string providerType)
        {
            IForecastService forecastService = ForecastProvider.GetService(providerType, _config.Object, _loggerService.Object);

            Assert.IsNull(forecastService);
        }
    }
}