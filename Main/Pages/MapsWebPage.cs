namespace MapsNavigationTestSuite.Main.Pages
{
    public class MapsWebPage
    {
        private readonly AppiumDriverSetup _driverSetup = new();
        private IWebDriver _driver;
        private readonly WebDriverWait _wait;

        [BeforeScenario("web")]
        public void Setup()
        {
            _driver = _driverSetup.InitializeDriver("web");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [AfterScenario("web")]
        public void Teardown()
        {
            _driverSetup.QuitDriver();
        }
        public MapsWebPage()
        {
            _driver = _driverSetup.InitializeDriver("web");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // var acceptButton = wait.Until(drv => drv.FindElement(By.XPath("//button[contains(., 'Accept')]")));
        public IWebElement acceptButton => _wait.Until(drv => drv.FindElement(
            By.XPath("//button[contains(., 'Accept')]")));
        
        public IWebElement SearchBox => _wait.Until(drv => drv.FindElement(
            By.XPath("//input[@id='searchboxinput']")));
        public IWebElement StartLocationInput => _wait.Until(drv => drv.FindElement(
            By.XPath("//div[@id='directions-searchbox-0']//input")));
        
        public IWebElement DestinationInput => _wait.Until(drv => drv.FindElement(
            By.XPath("//div[@id='directions-searchbox-1']//input")));
        
        public IWebElement TripDirections => _wait.Until(drv => drv.FindElement(
            By.XPath("//div[contains(@id, 'directions-trip')]")));
        
        // var directionsButton = wait.Until(drv => drv.FindElement(By.Id("hArJGc")));
        public IWebElement DirectionsButton => _wait.Until(drv => drv.FindElement(
            By.Id("hArJGc")));
        
        public void OpenMaps()
        {
            _driver.Navigate().GoToUrl("https://maps.google.com");
        }

        public void EnterStartLocation(string start)
        {
            StartLocationInput.SendKeys(start);
            StartLocationInput.SendKeys(Keys.Enter);
        }
        
        public void Enterdestination(string destination)
        {
            DestinationInput.Clear();
            DestinationInput.SendKeys(destination);
            DestinationInput.SendKeys(Keys.Enter);
        }
    }
}