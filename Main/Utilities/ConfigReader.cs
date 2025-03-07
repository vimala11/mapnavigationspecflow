namespace MapsNavigationTestSuite.Main.Utilities
{
    public static class ConfigReader
    {
        public static string GetConfigValue(string key) => ConfigurationManager.AppSettings[key];
    }
}