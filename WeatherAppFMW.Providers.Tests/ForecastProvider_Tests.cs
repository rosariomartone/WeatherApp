using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void GetProvider_RetrieveProvider(string providerType)
        {
            IForecastProvider provider = ForecastProvider.GetProvider(providerType, _config.Object);

            Assert.IsNotNull(provider);
        }

        /// <summary>
        /// Testing the provider is correctly not returned when the provider is invalid.
        /// </summary>
        /// <param name="providerType"></param>
        [TestMethod]
        [DataRow("MSSQL")]
        public void GetProvider_FailingRetrieveProvider(string providerType)
        {
            IForecastProvider provider = ForecastProvider.GetProvider(providerType, _config.Object);

            Assert.IsNull(provider);
        }
    }
}