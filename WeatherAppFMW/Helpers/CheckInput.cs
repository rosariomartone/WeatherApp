namespace WeatherAppFMW.Helpers
{
    public class CheckInput
    {
        public static bool IsLocationInputValid(string location)
        {
            return !string.IsNullOrEmpty(location);
        }
    }
}