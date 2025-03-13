using MapsNavigationTestSuite.Main.Pages;

namespace MapsNavigationTestSuite.Tests.Steps
{
    [Binding]
    public class MapsNavigationWebSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private MapsWebPage _mapsWebPage;
        
        public MapsNavigationWebSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have opened Google Maps in a browser")]
        public void GivenIHaveOpenedGoogleMapsInABrowser()
        {
            var driver = _scenarioContext["Driver"] as IWebDriver;
            _mapsWebPage = new MapsWebPage(driver);
            _mapsWebPage.OpenMaps(driver);
            
            try
            {
               _mapsWebPage.acceptButton.Click();
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
            _mapsWebPage.EnterStartLocation(start);
        }

        [When(@"I enter ""(.*)"" as the destination")]
        public void WhenIEnterAsTheDestination(string destination)
        {
            _mapsWebPage.Enterdestination(destination);
        }

        [Then(@"I should see directions to the Solirius Office")]
        public void ThenIShouldSeeDirectionsToTheSoliriusOffice()
        {
            Assert.That(_mapsWebPage.TripDirections.Displayed, Is.True, "Directions to Solirius Office not found!");
        }

        [WhenAttribute(@"I click on directions button")]
        public void WhenIClickOnDirectionsButton()
        {
            _mapsWebPage.DirectionsButton.Click();
        }
    }
}