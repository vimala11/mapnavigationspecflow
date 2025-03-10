
using MapsNavigationTestSuite.Main.Pages;

namespace MapsNavigationTestSuite.Tests.Steps
{
    [Binding]
    public class MapsNavigationMobileSteps
    {
        private readonly AppiumDriverSetup _driverSetup = new(); 
        
        // private static AppiumDriver _driver;
        
        
        
        private static BaseSteps _baseSteps = new BaseSteps();
        
        MapsMobilePage _mapsMobilePage = new MapsMobilePage(_baseSteps.Setup());
     
        // [BeforeScenario("mobile")] // Only for mobile scenarios
        // public void SetupDriver()
        // {
        //     // _driver = (AppiumDriver)_driverSetup.InitializeDriver("mobile");
        //     // BaseSteps baseSteps = new BaseSteps();
        //     // baseSteps.Setup();
        //     // _mapsMobilePage = new MapsMobilePage(baseSteps.Setup());
        //     
        // }
        // [AfterScenario("mobile")]
        // public void Teardown()
        // {
        //     _driverSetup.QuitDriver();
        // }
       

        [Given(@"I have opened Google Maps on my Android device")]
        public void GivenIHaveOpenedGoogleMaps()
        {
            
            Assert.That(_mapsMobilePage, Is.Not.Null, "Google Maps failed to open.");
        }

        [When(@"I enter ""(.*)"" as the mobile starting point")]
        public void WhenIEnterMobileStartingPoint(string startingPoint)
        {
            try
            {
                _mapsMobilePage.EnterStartLocation(startingPoint);
                _mapsMobilePage.PressEnterKey();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to enter starting point: {ex.Message}");
            }

        }

        [When(@"I enter ""(.*)"" as the mobile destination")]
        public void WhenIEnterMobileDestination(string destination){
            _mapsMobilePage.EnterDestination(destination);
            _mapsMobilePage.PressEnterKey();
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
    }
}