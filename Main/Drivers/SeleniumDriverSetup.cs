namespace MapsNavigationTestSuite.Main.Drivers
{
    public class SeleniumDriverSetup
    {
        private IWebDriver _driver;

        public IWebDriver InitializeDriver()
        {
            string browser = ConfigurationManager.AppSettings["Browser"];
            if (browser.Equals("Chrome", StringComparison.OrdinalIgnoreCase))
            {
                _driver = new ChromeDriver();
            }
            // Add other browsers if needed (e.g., FirefoxDriver)
            _driver.Manage().Window.Maximize();
            return _driver;
        }

        public void QuitDriver()
        {
            _driver?.Quit();
        }
    }
}