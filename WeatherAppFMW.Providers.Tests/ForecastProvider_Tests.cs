using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WeatherAppFMW.Providers.Tests
{
    [TestClass]
    public class ForecastProvider_Tests : BaseTest
    {
        [TestMethod]
        [DataRow("API")]
        public void GetProvider_RetrieveProvider(string providerType)
        {
            IForecastProvider provider = ForecastProvider.GetProvider(providerType, _config);

            Assert.IsNotNull(provider);
        }

        [TestMethod]
        [DataRow("MSSQL")]
        public void GetProvider_FailingRetrieveProvider(string providerType)
        {
            IForecastProvider provider = ForecastProvider.GetProvider(providerType, _config);

            Assert.IsNull(provider);
        }
    }
}