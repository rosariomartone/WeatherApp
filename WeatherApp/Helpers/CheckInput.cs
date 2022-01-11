namespace WeatherApp.Helpers
{
    internal static class CheckInput
    {
        public static bool IsLocationInputValid(string location)
        {
            return !string.IsNullOrEmpty(location);
        }
    }
}