using MapsNavigationTestSuite.Main.Utilities;
using MapsNavigationTestSuite.Tests.Steps;
using OpenQA.Selenium.Appium.Android.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace MapsNavigationTestSuite.Main.Pages
{
    public class MapsMobilePage
    {
        private readonly IWebDriver _driver;
        private readonly AppiumDriverSetup _driverSetup = new();
        private readonly WebDriverWait _wait;
        private readonly bool _isAndroid;

        public MapsMobilePage()
        {
            _driver = (AppiumDriver)_driverSetup.InitializeDriver("mobile");;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _isAndroid = _driver is AndroidDriver;
        }
        
        //public IWebElement DirectionsButton => _driver.FindElement(By.CssSelector("button[aria-label='Directions']"));
        private IWebElement StartLocationInput => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? MobileBy.AndroidUIAutomator("new UiSelector().text(\"Choose start location\")")
                : MobileBy.AccessibilityId("Start Location")
        ));

        public IWebElement DestinationInput => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? MobileBy.AndroidUIAutomator("new UiSelector().text(\"Choose destination\")")
                : MobileBy.AccessibilityId("Choose destination")
        ));
        
        // public IWebElement DirectionsPane => _driver.FindElement(By.Id("directions-panel"));
        public IWebElement DirectionsModeTabs => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? By.Id("com.google.android.apps.maps:id/directions_mode_tabs")
                : MobileBy.AccessibilityId("Choose destination")));
        
        public IWebElement DirectionsButton => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? By.Id("com.google.android.apps.maps:id/on_map_directions_button")
                : MobileBy.AccessibilityId("Directions")));

        public void NavigateToGoogleMaps()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/maps");
            // Report.test.Info("Open Google Maps Web Page");
        }
        
        public void EnterStartLocation(string location)
        {
            StartLocationInput.Click();
            StartLocationInput.SendKeys(location);
            // Report.test.Info("Clicked on element and entered start location");
        }

        public void EnterDestination(string destination)
        {
            DestinationInput.Click();
            DestinationInput.SendKeys(destination);
            // Report.test.Info("Clicked on element and entered destination");
        }

        public void PressEnterKey()
        {
            if (_isAndroid)
            {
                ((AndroidDriver)_driver).PressKeyCode(AndroidKeyCode.Enter);
            }
            else
            {
                _driver.FindElement(MobileBy.AccessibilityId("Done"));
            }
        }
    }
}