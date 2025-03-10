using NUnit.Framework.Interfaces;

namespace MapsNavigationTestSuite.Tests.Steps;

public class BaseSteps
{
    private readonly AppiumDriverSetup _driverSetup = new(); 
        
    private static AppiumDriver _driver;
    
     
    [BeforeScenario("mobile")] // Only for mobile scenarios
    public AppiumDriver Setup()
    {
        return (AppiumDriver)_driverSetup.InitializeDriver("mobile");
        // _mapsMobilePage = new MapsMobilePage(_driver);
            
    }
    
    [AfterScenario("mobile")]
    public void Teardown()
    {
        TakeScreenshot();
        _driverSetup.QuitDriver();
    }
    
    private void TakeScreenshot()
    {
        try
        {
            _driver= Setup();
            if (_driver != null)
            {
                if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                {
                    var screenshot = _driver.GetScreenshot();
                    string screenshotPath = $"{TestContext.CurrentContext.Test.MethodName}.png";
                    screenshot.SaveAsFile(screenshotPath);
                    // report.SaveScreenshotToReport(screenshotPath);
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception("Snapshot was not taken" + e.Message);
        }
    }

}