namespace WeatherApp.Models
{
    public interface IForecast
    {
        public string GetName();

        public string GetRegion();

        public string GetCountry();

        public double GetLatitude();

        public double GetLongitude();

        public string GetTimeZone();

        public string GetCurrentTime();
    }
}