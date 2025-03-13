using OpenQA.Selenium.Appium.Android.Enums;

namespace MapsNavigationTestSuite.Main.Pages
{
    public class MapsMobilePage
    {
        private readonly WebDriverWait _wait;
        private readonly bool _isAndroid;

        public MapsMobilePage(IWebDriver driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _isAndroid = driver is AndroidDriver;
        }
        
        private IWebElement StartLocationInput => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? MobileBy.AndroidUIAutomator("new UiSelector().text(\"Choose start location\")")
                : MobileBy.AccessibilityId("WaypointSearchField")
        ));

        public IWebElement DestinationInput => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? MobileBy.AndroidUIAutomator("new UiSelector().text(\"Choose destination\")")
                : MobileBy.AccessibilityId("MapsSearchTextField")
        ));
        
        public IWebElement DirectionsModeTabs => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? By.Id("com.google.android.apps.maps:id/directions_mode_tabs")
                : MobileBy.AccessibilityId("TransportTypePicker")));
        
        public IWebElement DirectionsButton => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? By.Id("com.google.android.apps.maps:id/on_map_directions_button")
                : MobileBy.AccessibilityId("PlaceSummaryActionButton")));
        
        public IWebElement FirstOptionOfStartLoc => _wait.Until(drv => drv.FindElement(
            _isAndroid
                ? By.Id("com.google.android.apps.maps:id/on_map_directions_button")
                : MobileBy.IosClassChain("**/XCUIElementTypeStaticText[`name == \"PlaceSummaryTitleLabel\"`][1]")));
        
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

        public void PressEnterKey(IWebDriver driver)
        {
            if (_isAndroid)
            {
                ((AndroidDriver)driver).PressKeyCode(AndroidKeyCode.Enter);
            }
            else
            {
                driver.FindElement(MobileBy.AccessibilityId("Done"));
            }
        }
    }
}