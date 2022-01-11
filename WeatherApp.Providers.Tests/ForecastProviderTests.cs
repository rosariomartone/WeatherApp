using NUnit.Framework;

namespace WeatherApp.Providers.Tests
{
    public class ForecastProviderTests : BaseTest
    {
        [Test]
        [TestCase("API")]
        public void GetProvider_RetrieveProvider(string providerType)
        {
            IForecastProvider provider = ForecastProvider.GetProvider(providerType, _config);

            Assert.IsNotNull(provider);
        }

        [Test]
        [TestCase("MSSQL")]
        public void GetProvider_FailingRetrieveProvider(string providerType)
        {
            IForecastProvider provider = ForecastProvider.GetProvider(providerType, _config);

            Assert.IsNull(provider);
        }
    }
}