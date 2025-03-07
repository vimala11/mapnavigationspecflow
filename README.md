# Maps Navigation Test Suite

Automates navigation in Google Maps using C#, Appium (Android), and Selenium (Chrome) with SpecFlow in JetBrains Rider.

## Prerequisites

### **JetBrains Rider (2024.3+)**
- [Download JetBrains Rider](https://www.jetbrains.com/rider/download/)
- Install via installer or JetBrains Toolbox.

### **.NET 9 SDK**
- Install: `winget install Microsoft.DotNet.SDK.9`
- Verify: `dotnet --version`

### **Appium Server**
- Install Node.js: `winget install OpenJS.NodeJS`
- Install Appium: `npm install -g appium`
- Verify: `appium --version`

### **Android Emulator/Device**
- Install [Android Studio](https://developer.android.com/studio)
- Setup Emulator:
    - Android Studio > Configure > AVD Manager > Create (e.g., Pixel 6, Android 13).
- Install Google Maps via Play Store.
- Set `ANDROID_HOME`:
  ```powershell
  [System.Environment]::SetEnvironmentVariable("ANDROID_HOME", "C:\Users\<YourUser>\AppData\Local\Android\Sdk", "User")
  ```

### **Chrome Browser**
- Install: [Google Chrome](https://www.google.com/chrome/)
- Check Version:
  ```powershell
  & "C:\Program Files\Google\Chrome\Application\chrome.exe" --version
  ```

### **ChromeDriver**
- Uses v129.0.6668.5800 (Chrome 129).
- Verify:
  ```sh
  dotnet restore MapsNavigationTestSuite.sln
  ```

### **PowerShell**
- Update: `winget install Microsoft.PowerShell`

### **Git**
- Install: `winget install Git.Git`

## Setup

### **1. Clone Repository**
```sh
git clone <repository-url>
cd MapsNavigationTestSuite
```

### **2. Restore Dependencies**
```sh
dotnet restore MapsNavigationTestSuite.sln
```

### **3. Configure Appium**
```sh
appium --port 4724
adb devices  # Ensure emulator/device is connected
```

### **4. Verify Configuration (`App.config`)**
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <appSettings>
        <add key="AppiumServer" value="http://localhost:4724/wd/hub" />
        <add key="PlatformName" value="Android" />
        <add key="PlatformVersion" value="13.0" />
        <add key="DeviceName" value="Pixel_6" />
        <add key="AppPackage" value="com.google.android.apps.maps" />
        <add key="AppActivity" value="com.google.android.maps.MapsActivity" />
        <add key="AutomationName" value="UiAutomator2" />
        <add key="Browser" value="Chrome" />
    </appSettings>
</configuration>
```

## Running Tests

### **From Command Line**

#### **Web Test (Basic)**
```sh
dotnet test MapsNavigationTestSuite.sln --filter "FullyQualifiedName~NavigateFromLondonBridgeToSoliriusOfficeOnWeb"
```

#### **Web Test (Verbose)**
```sh
dotnet test MapsNavigationTestSuite.sln --filter "FullyQualifiedName~NavigateFromLondonBridgeToSoliriusOfficeOnWeb" --logger "console;verbosity=detailed"
```

#### **Mobile Test (Basic)**
Start Appium, then:
```sh
dotnet test MapsNavigationTestSuite.sln --filter "FullyQualifiedName~NavigateFromLondonBridgeToSoliriusOfficeOnMobile"
```

#### **Mobile Test (Verbose)**
```sh
dotnet test MapsNavigationTestSuite.sln --filter "FullyQualifiedName~NavigateFromLondonBridgeToSoliriusOfficeOnMobile" --logger "console;verbosity=detailed"
```

### **From Rider**
- Open `MapsNavigationWeb.feature` or `MapsNavigationMobile.feature`.
- Right-click scenario > **Run**.

## Viewing Reports

### **Console Output**
- **Basic**: Pass/fail summary.
- **Verbose**: Step-by-step logs.

### **NUnit XML Report**
- Location: `MapsNavigationTestSuite\bin\Debug\net9.0\TestResults\*.trx`
- View:
  ```sh
  notepad MapsNavigationTestSuite\bin\Debug\net9.0\TestResults\*.trx
  ```
- **Rider**: Navigate to **Unit Tests > Right-click test > Show Results**.

### **Customizing Reports**
Add:
```sh
dotnet test --logger "trx"
```


