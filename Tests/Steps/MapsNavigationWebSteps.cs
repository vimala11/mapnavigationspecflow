using MapsNavigationTestSuite.Main.Pages;

namespace MapsNavigationTestSuite.Tests.Steps
{
    [Binding]
    public class MapsNavigationWebSteps
    {
        private MapsWebPage _mapsWebPage = new MapsWebPage();
        // private readonly AppiumDriverSetup _driverSetup = new();
        // private IWebDriver _driver;
        //
        // [BeforeScenario("web")]
        // public void Setup()
        // {
        //     _driver = _driverSetup.InitializeDriver("web");
        //     _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        // }
        //
        // [AfterScenario("web")]
        // public void Teardown()
        // {
        //     _driverSetup.QuitDriver();
        // }

        [Given(@"I have opened Google Maps in a browser")]
        public void GivenIHaveOpenedGoogleMapsInABrowser()
        {
            // _driver.Navigate().GoToUrl("https://maps.google.com");
            _mapsWebPage.OpenMaps();
            // var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            try
            {
                // var acceptButton = wait.Until(drv => drv.FindElement(By.XPath("//button[contains(., 'Accept')]")));
               _mapsWebPage.acceptButton.Click();
                // wait.Until(drv => drv.FindElement(By.XPath("//input[@id='searchboxinput']")));
                Assert.That(_mapsWebPage.SearchBox.Displayed, Is.True, "Google Maps search box is not displayed!");
                Console.WriteLine("Consent screen accepted.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("No consent screen found, proceeding...");
            }
        }

        [When(@"I enter ""(.*)"" as the starting point")]
        public void WhenIEnterAsTheStartingPoint(string start)
        {
            // var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // //var searchBox = wait.Until(drv => drv.FindElement(By.XPath("//input[@id='searchboxinput']")));
            // var searchBox = wait.Until(drv => drv.FindElement(By.XPath("//div[@id='directions-searchbox-0']//input")));
            _mapsWebPage.EnterStartLocation(start);
            // searchBox.SendKeys(start);
            // searchBox.SendKeys(Keys.Enter);
        }

        [When(@"I enter ""(.*)"" as the destination")]
        public void WhenIEnterAsTheDestination(string destination)
        {
            // var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // var directionsButton = wait.Until(drv => drv.FindElement(By.XPath("//button[@data-value='Directions']")));
            // directionsButton.Click();
            // var destBox = wait.Until(drv => drv.FindElement(By.XPath("//div[@id='directions-searchbox-1']//input")));
            // destBox.Clear();
            // destBox.SendKeys(destination);
            // destBox.SendKeys(Keys.Enter);
            _mapsWebPage.Enterdestination(destination);
        }

        [Then(@"I should see directions to the Solirius Office")]
        public void ThenIShouldSeeDirectionsToTheSoliriusOffice()
        {
            // var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20)); // Longer wait
            // var directions = wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@id, 'directions-trip')]")));
            Assert.That(_mapsWebPage.TripDirections.Displayed, Is.True, "Directions to Solirius Office not found!");
        }

        [WhenAttribute(@"I click on directions button")]
        public void WhenIClickOnDirectionsButton()
        {
            // var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // var directionsButton = wait.Until(drv => drv.FindElement(By.Id("hArJGc")));
            _mapsWebPage.DirectionsButton.Click();
        }
    }
}