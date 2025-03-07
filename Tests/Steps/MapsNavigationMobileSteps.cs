using MapsNavigationTestSuite.Main.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android; // For AndroidDriver
using TechTalk.SpecFlow;

namespace MapsNavigationTestSuite.Tests.Steps
{
    [Binding]
    public class MapsNavigationMobileSteps
    {
        private readonly AppiumDriverSetup _driverSetup = new();
        private AndroidDriver _driver; // Back to AndroidDriver for mobile-specific methods

     
        [BeforeScenario("mobile")] // Only for mobile scenarios
        public void Setup()
        {
            _driver = (AndroidDriver)_driverSetup.InitializeDriver("mobile");
        }
        [AfterScenario("mobile")]
        public void Teardown()
        {
            _driverSetup.QuitDriver();
        }
       

        [Given(@"I have opened Google Maps on my Android device")]
        public void GivenIHaveOpenedGoogleMaps()
        {
            Assert.That(_driver, Is.Not.Null, "Google Maps failed to open.");
        }

        [When(@"I enter ""(.*)"" as the mobile starting point")]
        public void WhenIEnterMobileStartingPoint(string startingPoint)
        {
            var searchBox = _driver.FindElement(By.Id("com.google.android.apps.maps:id/search_omnibox_text_box"));
            searchBox.Click();
            var editBox = _driver.FindElement(By.Id("com.google.android.apps.maps:id/search_omnibox_edit_text"));
            editBox.SendKeys(startingPoint);
            _driver.PressKeyCode(66); // Enter key - works with AndroidDriver
        }

        [When(@"I enter ""(.*)"" as the mobile destination")]
        public void WhenIEnterMobileDestination(string destination)
        {
            var directionsButton = _driver.FindElement(By.Id("com.google.android.apps.maps:id/directions_button"));
            directionsButton.Click();
            var destinationBox = _driver.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.google.android.apps.maps:id/destination_text']"));
            destinationBox.SendKeys(destination);
            _driver.PressKeyCode(66); // Enter key
        }

        [When(@"I start navigation")]
        public void WhenIStartNavigation()
        {
            var startButton = _driver.FindElement(By.Id("com.google.android.apps.maps:id/start_button"));
            startButton.Click();
        }

        [Then(@"I should see mobile directions to the Solirius Office")]
        public void ThenIShouldSeeMobileDirections()
        {
            var navigationPane = _driver.FindElement(By.Id("com.google.android.apps.maps:id/navigation_container"));
            Assert.That(navigationPane.Displayed, Is.True, "Navigation directions not displayed.");
        }
    }
}