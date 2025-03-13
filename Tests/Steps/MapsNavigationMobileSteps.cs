
using MapsNavigationTestSuite.Main.Pages;

namespace MapsNavigationTestSuite.Tests.Steps
{
    [Binding]
    public class MapsNavigationMobileSteps
    {
        private static ScenarioContext _scenarioContext;
        private static IWebDriver driver; 
        private MapsMobilePage _mapsMobilePage;

        public MapsNavigationMobileSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext["Driver"] as IWebDriver;
            _mapsMobilePage = new MapsMobilePage(driver);
        }

        [Given(@"I have opened Google Maps on my Android device")]
        public void GivenIHaveOpenedGoogleMaps()
        {
            Assert.That(_mapsMobilePage, Is.Not.Null, "Maps failed to open.");
        }

        [When(@"I enter ""(.*)"" as the mobile starting point")]
        public void WhenIEnterMobileStartingPoint(string startingPoint)
        {
            try
            {
                _mapsMobilePage.EnterStartLocation(startingPoint);
                _mapsMobilePage.PressEnterKey(driver);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to enter starting point: {ex.Message}");
            }

        }

        [When(@"I enter ""(.*)"" as the mobile destination")]
        public void WhenIEnterMobileDestination(string destination){
            _mapsMobilePage.EnterDestination(destination);
            _mapsMobilePage.PressEnterKey(driver);
        }
        
        [When(@"I click on directions button on map")]
        public void WhenIClickOnDirectionsButtonOnMap()
        {
            _mapsMobilePage.DirectionsButton.Click();
        }

        [ThenAttribute(@"I should see available modes of travel to the Solirius Office")]
        public void ThenIShouldSeeAvailableModesOfTravelToTheSoliriusOffice()
        {
            Assert.That(_mapsMobilePage.DirectionsModeTabs.Displayed, Is.True, "Direction mode tabs are not displayed.");
        }

        [WhenAttribute(@"I click the first option displayed")]
        public void WhenIClickTheFirstOptionDisplayed()
        {
            _mapsMobilePage.FirstOptionOfStartLoc.Click();
        }
    }
}