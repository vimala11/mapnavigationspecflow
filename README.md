Maps Navigation Test Suite
Automates navigation in Google Maps using C#, Appium (Android), and Selenium (Chrome) with SpecFlow in JetBrains Rider.
Prerequisites
JetBrains Rider (2024.3+)
* Download JetBrains Rider
* Install via installer or JetBrains Toolbox.
  .NET 8 SDK
* Install: winget install Microsoft.DotNet.SDK.8
* Verify: dotnet --version
  Appium Server
* Install Node.js: winget install OpenJS.NodeJS
* Install Appium: npm install -g appium
* Verify: appium --version
  Android Emulator/Device
* Install Android Studio
* Setup Emulator:
    * Android Studio > Configure > AVD Manager > Create (e.g., Pixel 6, Android 13).
* Install Google Maps via Play Store.
* Set ANDROID_HOME:
  Chrome Browser
* Install: Google Chrome
* Check Version:
*  dotnet restore MapsNavigationTestSuite.sln
*

Git
* Install: winget install Git.Git

Setup
1. Clone Repository
   ￼

￼
git clone <repository-url>
cd MapsNavigationTestSuite
2. Restore Dependencies
   ￼

￼
dotnet restore MapsNavigationTestSuite.sln
3. Configure Appium
   ￼

￼
appium --port 4723
adb devices  # Ensure emulator/device is connected
4. Verify Configuration (App.config)
   ￼

<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <appSettings>
        <add key="AppiumServer" value="http://localhost:4723/" />
        <add key="PlatformName" value="Android" />
        <add key="PlatformVersion" value="13.0" />
        <add key="DeviceName" value="Pixel_6" />
        <add key="AppPackage" value="com.google.android.apps.maps" />
        <add key="AppActivity" value="com.google.android.maps.MapsActivity" />
        <add key="AutomationName" value="UiAutomator2" />
        <add key="Browser" value="Chrome" />
    </appSettings>
</configuration>
Running Tests
From Command Line
Web Test (Basic)
￼

￼
dotnet test MapsNavigationTestSuite.sln --filter "FullyQualifiedName~NavigateFromLondonBridgeToSoliriusOfficeOnWeb"
Web Test (Verbose)
￼

￼
dotnet test MapsNavigationTestSuite.sln --filter "FullyQualifiedName~NavigateFromLondonBridgeToSoliriusOfficeOnWeb" --logger "console;verbosity=detailed"
Mobile Test (Basic)
Start Appium, then:
￼

￼
dotnet test MapsNavigationTestSuite.sln --filter "FullyQualifiedName~NavigateFromLondonBridgeToSoliriusOfficeOnMobile"
From Rider
* Open MapsNavigationWeb.feature or MapsNavigationMobile.feature.
* Right-click scenario > Run.
  Viewing Reports
  Console Output
* Extent Reports
* Location: mapnavigationspecflow/bin/Debug/net8.0/index.html

