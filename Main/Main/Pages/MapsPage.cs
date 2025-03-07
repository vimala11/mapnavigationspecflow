using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MapsNavigationTestSuite.Main.Pages
{
    public class MapsPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public MapsPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Made properties public
        public IWebElement SearchBox => _driver.FindElement(By.Id("searchboxinput"));
        public IWebElement DirectionsButton => _driver.FindElement(By.CssSelector("button[aria-label='Directions']"));
        public IWebElement StartInput => _driver.FindElement(By.XPath("//input[@placeholder='Choose starting point...']"));
        public IWebElement DestinationInput => _driver.FindElement(By.XPath("//input[@placeholder='Choose destination...']"));
        public IWebElement DirectionsPane => _driver.FindElement(By.Id("directions-panel"));

        public void NavigateToGoogleMaps()
        {
            _driver.Navigate().GoToUrl("https://www.google.com/maps");
        }

        public void EnterStartingPoint(string start)
        {
            SearchBox.Clear();
            SearchBox.SendKeys(start);
            SearchBox.SendKeys(Keys.Enter);
            _wait.Until(d => DirectionsButton.Displayed);
            DirectionsButton.Click();
            StartInput.Clear();
            StartInput.SendKeys(start);
        }

        public void EnterDestination(string destination)
        {
            DestinationInput.Clear();
            DestinationInput.SendKeys(destination);
            DestinationInput.SendKeys(Keys.Enter);
        }

        public bool AreDirectionsDisplayed()
        {
            return _wait.Until(d => DirectionsPane.Displayed);
        }
    }
}