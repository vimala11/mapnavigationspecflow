using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace DemoFrameworkForExtentReports.Utility
{
    public class ExtentReport
    {
        protected static ExtentReports ExtentReports;
        protected static ExtentTest Feature;
        protected static ExtentTest Scenario;

        private static readonly String Dir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly String TestResultPath = Dir.Replace("mapnavigationspecflow/Main/", "Reports");

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(TestResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            ExtentReports = new ExtentReports();
            ExtentReports.AttachReporter(htmlReporter);
            ExtentReports.AddSystemInfo("Application", "Google Maps");
        }

        public static void ExtentReportTearDown()
        {
            ExtentReports.Flush();
        }

        public string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(TestResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }
    }
}