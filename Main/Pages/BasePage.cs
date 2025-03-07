// using MapsNavigationTestSuite.Main.Utilities;
// using NUnit.Framework;
// using NUnit.Framework.Interfaces;
//
// namespace MapsNavigationTestSuite.Tests.Steps
// {
//     public class BasePage
//     {
//         private readonly AppiumDriverSetup _driverSetup = new();
//         public static AppiumDriver _driver;
//
//         // [OneTimeSetUp]
//         // public void OneTimeSetUp()
//         // {
//         //     // Start the report
//         //     _report.StartReport();
//         // }
//
//         // [BeforeScenario ("mobile")]
//         // [SetUp] // Runs before each test
//         // public void Setup()
//         // {
//         //     // Initialize Appium driver only once per test
//         //     if (_driver == null)
//         //     {
//         //         _driver = (AppiumDriver)_driverSetup.InitializeDriver("mobile");
//         //     }
//         // }
//
//         [TearDown] // Runs after each test
//         public void Teardown()
//         {
//             try
//             {
//                 // Attach screenshot if the test failed
//                 // AttachScreenshotToTheReport();
//             }
//             finally
//             {
//                 // Quit the driver after each test
//                 _driverSetup.QuitDriver();
//                 _driver = null; // Reset driver for next test
//             }
//         }
//     }
//
// }