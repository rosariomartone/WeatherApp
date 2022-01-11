using Newtonsoft.Json;

namespace WeatherApp.Helpers
{
    public class API
    {
        [JsonProperty("WeatherAPIUrl_Forecast")]
        public string WeatherAPIUrlForecast { get; set; }
    }

    public class AppSettings
    {
        [JsonProperty("API")]
        public API API { get; set; }
    }
}