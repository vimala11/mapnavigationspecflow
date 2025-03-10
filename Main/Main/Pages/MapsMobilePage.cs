using OpenQA.Selenium.Appium.Android.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace MapsNavigationTestSuite.Main.Pages
{
    public class MapsMobilePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly bool _isAndroid;

        public MapsMobilePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _isAndroid = driver is AndroidDriver;
        }

        // Made properties public
        public IWebElement SearchBox => _driver.FindElement(By.Id("searchboxinput"));
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
        }
        
        public void EnterStartLocation(string location)
        {
            StartLocationInput.Click();
            StartLocationInput.SendKeys(location);
        }

        public void EnterDestination(string destination)
        {
            DestinationInput.Click();
            DestinationInput.SendKeys(destination);
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