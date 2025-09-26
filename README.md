# TestCore Package

This package contains core utilities for Unity projects including Logger, Analytics, and Firebase Analytics Provider.

## Installation

1. **Add the package to your project:**
   
   Add this line to your `Packages/manifest.json`:
   ```json
   "com.jarzykk.test-core": "https://github.com/Jarzykk/Core-Packages.git"
   ```

2. **Install required dependencies:**

   The package requires these dependencies to work properly. Add them to your `Packages/manifest.json`:

   ```json
   {
     "dependencies": {
       "com.jarzykk.test-core": "https://github.com/Jarzykk/Core-Packages.git",
       "com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask",
       "com.svermeulen.extenject": "9.2.1"
     }
   }
   ```

3. **For Firebase Analytics (optional):**
   
   If you want to use Firebase Analytics:
   - Install Firebase SDK from Unity Package Manager or Firebase Console
   - Import the Firebase Analytics package
   - The Firebase Analytics provider will be available automatically

## Features

- **Logger System**: Comprehensive logging with channels and styles
- **Analytics Core**: Event tracking system with multiple providers
- **Firebase Analytics Provider**: Firebase integration for analytics
- **Network Service**: Network reachability utilities
- **Test Utilities**: Various testing and development tools

## Usage

```csharp
// Logger example
Logger.Log("Hello World", LogLevel.Info);

// Analytics example
var analyticEvent = new AnalyticEvent("user_action", new Dictionary<string, object> 
{ 
    {"action_type", "button_click"} 
});
AnalyticService.SendEvent(analyticEvent);
```

## Dependencies

- **UniTask**: For async operations
- **Extenject (Zenject)**: For dependency injection
- **Firebase Analytics**: For Firebase analytics provider (optional)

## License

See LICENSE.md for details.