﻿using OpenQA.Selenium.Appium.iOS;

namespace MapsNavigationTestSuite.Main.Drivers
{
    public class AppiumDriverSetup
    {
        private IWebDriver _driver; // Unified driver type

        public IWebDriver InitializeDriver(string testType = "mobile")
        {
            if (testType.ToLower() == "web")
            {
                _driver = new ChromeDriver(); // Web uses ChromeDriver
            }
            else // Default to mobile
            {
                var options = new AppiumOptions();
                options.PlatformName = ConfigurationManager.AppSettings["PlatformName"] ?? "Android";
                options.PlatformVersion = ConfigurationManager.AppSettings["PlatformVersion"] ?? "15";
                options.DeviceName = ConfigurationManager.AppSettings["DeviceName"] ?? "Pixel_7";
                options.AutomationName = ConfigurationManager.AppSettings["AutomationName"] ?? "UiAutomator2";
                options.AddAdditionalAppiumOption("appPackage", ConfigurationManager.AppSettings["AppPackage"] ?? "com.google.android.apps.maps");
                options.AddAdditionalAppiumOption("appActivity", ConfigurationManager.AppSettings["AppActivity"] ?? "com.google.android.maps.MapsActivity");

                string appiumServer = ConfigurationManager.AppSettings["AppiumServer"] ?? "http://127.0.0.1:4723/";
                if (string.IsNullOrEmpty(appiumServer))
                {
                    throw new InvalidOperationException("AppiumServer URL is not configured in App.config.");
                }

                if (options.PlatformName == "Android")
                {
                    options.AddAdditionalAppiumOption("uiautomator2ServerLaunchTimeout", 120000);
                    _driver = new AndroidDriver(new Uri(appiumServer), options); // Mobile uses AndroidDriver
                } else if (options.PlatformName == "iOS")
                {
                    options.AddAdditionalAppiumOption("wdaLaunchTimeout", 120000);
                    options.AddAdditionalAppiumOption("wdaConnectionTimeout", 120000);
                    options.AddAdditionalAppiumOption("commandTimeouts", 120000);
                    try
                    {
                        _driver = new IOSDriver(new Uri(appiumServer), options); // Mobile uses iOSDriver   
                        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
                        wait.Until(d => d.PageSource != null);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error starting driver: {ex.Message}");
                    }
                }

            }
            Console.WriteLine($"Initializing driver for: {testType}");
            return _driver;
        }
        public void QuitDriver()
        {
            _driver?.Quit();
        }
    }
}