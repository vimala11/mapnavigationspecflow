namespace MapsNavigationTestSuite.Main.Pages
{
    [Binding]
    public class MapsWebPage
    {
        private readonly WebDriverWait _wait;
        
        public MapsWebPage(IWebDriver driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement acceptButton => _wait.Until(drv => drv.FindElement(
            By.CssSelector("button[aria-label='Accept all']")));

        public IWebElement SearchBox => _wait.Until(drv => drv.FindElement(
            By.Id("searchboxinput")));

        public IWebElement StartLocationInput => _wait.Until(drv => drv.FindElement(
            By.XPath("//div[@id='directions-searchbox-0']//input")));

        public IWebElement DestinationInput => _wait.Until(drv => drv.FindElement(
            By.XPath("//div[@id='directions-searchbox-1']//input")));
        
        public IWebElement TripDirections => _wait.Until(drv => drv.FindElement(
            By.Id("section-directions-trip-0")));
        
        public IWebElement DirectionsButton => _wait.Until(drv => drv.FindElement(
            By.Id("hArJGc")));
        
        public void OpenMaps(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://maps.google.com");
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