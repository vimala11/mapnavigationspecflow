using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using DemoFrameworkForExtentReports.Utility;

namespace MapsNavigationTestSuite.Main.Pages
{
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        private readonly ScenarioContext _scenarioContext; 
        private IWebDriver _driver;
        private AppiumDriverSetup _driverSetup = new();

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            Feature = ExtentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [BeforeScenario("@web")]
        public void BeforeScenarioWithTagWeb()
        {
            Console.WriteLine("Running inside tagged hooks in a specflow");
        }
        
        [BeforeScenario("@mobile")]
        public void BeforeScenarioWithTagMobile(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running inside tagged hooks for mobile");
            _driver = (AppiumDriver)_driverSetup.InitializeDriver("mobile");;
            _scenarioContext["Driver"] = _driver;
            
            Scenario = Feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        
        [BeforeScenario("@web")]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            IWebDriver driver = new ChromeDriver();
            _scenarioContext["Driver"] = driver;
            driver.Manage().Window.Maximize();

            Scenario = Feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario("@web")]
        public void AfterScenario()
        {
            var driver = _scenarioContext["Driver"] as IWebDriver;

            if (driver != null)
            {
                driver.Close();
            }
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _scenarioContext["Driver"] as IWebDriver;

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    Scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    Scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    Scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    Scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    Scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    Scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    Scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    Scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}