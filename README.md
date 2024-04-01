# PrettyLogSharp
A C# logging library focused on readability in console. PrettyLog takes advantage of ANSI color codes to make your logs look ✨ pretty ✨. This whole project is inspired by Kotlin version of [PrettyLog](https://github.com/LukynkaCZE/PrettyLog) made by [LukynkaCZE](https://github.com/LukynkaCZE).

## Installation
WIP

## Logging
After installation, it's very simple to just start logging! All you need to do is call the `PrettyLogger.Log(string message, LogType logType)` static method. `LogType` parameter is optional. When it's not set
the default Information type is used.

```csharp
PrettyLogger.Log("Hello from PrettyLog!");
PrettyLogger.Log("You're gonna have a lot of time logging!", LogType.Warning);
```

<img width="537" alt="image" src="https://github.com/dalibor-osu/PrettyLogSharp/assets/77931392/2e3d584d-6f49-4ff4-ae39-1c2525de6471">

<br>
<br>

If you are used to standard [LogLevel enum](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel) from [Microsoft.Extensions.Logging namespace](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging), you can use it instead of the LogType.
If you do so, it is converted to its assigned LogType equivalent which can be customized. We will talk more about customization later.

```csharp
PrettyLogger.Log("I'm using LogLevel", LogLevel.Information);
PrettyLogger.Log("This is an error :(", LogLevel.Error);
```

<img width="403" alt="image" src="https://github.com/dalibor-osu/PrettyLogSharp/assets/77931392/13537e5f-6bdd-4462-9ec2-b2c51632c123">

<br>
<br>

Third way you can use to log is logging exceptions! Simply call the same method, but pass an Exception instance instead of string message.

```csharp
try
{
    int.Parse("Definitely not... a number");
}
catch (Exception exception)
{
    PrettyLogger.Log(exception);
}
```

<img width="793" alt="image" src="https://github.com/dalibor-osu/PrettyLogSharp/assets/77931392/b498004f-8a11-4822-b43e-dcfc6bbcd143">

**Quick tip:**

If you don't want to type "PrettyLogger" in front of every log call, you can use the static version of the using keyword!

```csharp
using static PrettyLogSharp.PrettyLogger;
...
Log("This is shorter!");
```

## Logger settings
There are 3 main categories of logger settings. Customizing the general settings, file logging and default LogTypes. Let's take a look at how you can use them and make your logs even more ✨ 𝙥𝙧𝙚𝙩𝙩𝙮 ✨.
Keep in mind we won't go through all customizable settings. If you'd like to check out what can be customized, please refer to a class that is linked in every section. These linked classes are very simple
and all they do is hold data to be used later when logging. Everything is documented and described there.

### General settings
First category of customization are general settings. These settings can be changed using the [LoggerSettings class](https://github.com/dalibor-osu/PrettyLogSharp/blob/master/PrettyLogSharp/Settings/LoggerSettings.cs). This class contains settings like the style of the logger, minimal log level and many others. It is also a main container for
all other settings classes which we will talk about later. To use custom settings, simply create a new instance of this class an initialize it with values you want. Uninitialized properties will remain at
their default values, so feel free to change only things you want to change. After that, you'll need to call the `PrettyLog.Initialize(settings)` metod to load the settings. In the following example, we will change the logger style (more about styles later) and set a minimal log level.

```csharp
// Creating the settings instance
var loggerSettings = new LoggerSettings
{
    LoggerStyle = LoggerStyle.Full,
    LogLevel = LogLevel.Warning
};

// Now we must call the Initialize() method to properly load the settings
PrettyLogger.Initialize(loggerSettings);

// We can start logging!
PrettyLogger.Log("This won't be logged.", LogLevel.Debug);
PrettyLogger.Log("This will be logged!", LogLevel.Error);
```
The output of this code will be:

<img width="414" alt="image" src="https://github.com/dalibor-osu/PrettyLogSharp/assets/77931392/56050468-aaed-4277-b0f4-ba6765d2e74f">

As you can see, the first log was not logged, because its LogLevel is lower than the minimal LogLevel we set in the settings. Also, the timestamp that was printed before the name of the LogType disappeared.

### File logging
PrettyLog also allows you to turn on logging to file. This can be done using the [FileWriterSettings class](https://github.com/dalibor-osu/PrettyLogSharp/blob/master/PrettyLogSharp/Settings/FileWriterSettings.cs).
It works in the same way as the [LoggerSettings class](https://github.com/dalibor-osu/PrettyLogSharp/blob/master/PrettyLogSharp/Settings/LoggerSettings.cs), but is specialized on file logging. As mentioned before,
the main container of all settings is the [LoggerSettings class](https://github.com/dalibor-osu/PrettyLogSharp/blob/master/PrettyLogSharp/Settings/LoggerSettings.cs), so to correctly apply our file logging settings, we need to set the `FileWriterSettings` property in it. In the following example, we will allow the file logging and set that we want the timestamp shown in the file to be in UTC.

```csharp
// Creating the file writer settings instance
var fileWriterSettings = new FileWriterSettings
{
    SaveToFile = true,
    UseUtc = true
};

// We must to set the file writer settings in general settings class
var loggerSettings = new LoggerSettings { FileWriterSettings = fileWriterSettings };

// Call the Initialize() method to properly load the settings
PrettyLogger.Initialize(loggerSettings);

// We can start logging!
PrettyLogger.Log("This is some kind of log.");
PrettyLogger.Log("This is also some kind of log but Error!", LogLevel.Error);
```
The console output will look like this:

<img width="521" alt="image" src="https://github.com/dalibor-osu/PrettyLogSharp/assets/77931392/9e956c0a-2e1e-46b5-b199-ca4d7d49b2f4">

And the file content will look like this:

```
2024-04-01 21:44:33:592 [ℹ️ Information] This is some kind of log.
2024-04-01 21:44:33:620 [⛔ Error] This is also some kind of log but Error!
```

As you can see, the timestamp shows a different time, because it is in UTC and the time printed to the console is in our local time (UTC+2).

**IMPORTANT:** Don't forget to set the `SaveToFile` property to `true`, otherwise file logging will remain disabled and all your settings will be ignored.

### Default LogTypes
As mentioned in the beggining, there is a way to log using Microsoft's [LogLevel enum](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel), but how will the logger know what format (LogType) to use? Well, there are some default LogTypes already set and what's even better is you can change them to make you logs even more ✨ 𝙥𝙧𝙚𝙩𝙩𝙮 ✨. Since we don't know how to create a custom LogType yet, let's try to set the default LogType of `LogLevel.Information` level to predefined Error LogType. Changing the defaults will make more sense once we learn how to customize the visuals of the logger!

```csharp
// First we need to create the instance of out logger defaults class
var loggerDefaultLogTypes = new LoggerDefaultLogTypes
{
    Information = LogType.Error
};

// Now we have to assign it in the general settings class
var loggerSettings = new LoggerSettings { DefaultLogTypes = loggerDefaultLogTypes };

// Call the Initialize() method to properly load the settings
PrettyLogger.Initialize(loggerSettings);

// We can start logging!
PrettyLogger.Log("This.. looks like an Error now?");
PrettyLogger.Log("Even when we explicitly say this is an Information?!", LogLevel.Information);
PrettyLogger.Log("This is what error looks like for comparison.", LogLevel.Error);
PrettyLogger.Log("We can also still use the predefined LogType explicitly, so the default is not used!", LogType.Information);
```

The output will look like this:

<img width="930" alt="image" src="https://github.com/dalibor-osu/PrettyLogSharp/assets/77931392/53e42fe6-d1a9-41a3-9b50-46417cccbbcb">

We hope this example also clarifies the difference between `LogType` and `LogLevel`. PrettyLogger **ALWAYS** uses `LogType` at the end, so every `LogLevel` must have its `LogType` assigned. When `LogLevel` is used for logging, it gets converted to its assigned `LogType` (you can use `LogLevel` just because it can be convenient and I believe a lot of people are used to it). `LogLevel` is also one of the properties of `LogType`, so certain `LogTypes` can be ignored when logging if the minimal `LogLevel` is higher (the reason you set the minimal `LogLevel` and not `LogType` is because you can create custom `LogTypes` and there is currently no way to determinate how high in severity it is).

## Custom LogTypes
As mentioned before, PrettyLogger allows you to create your own custom LogTypes, so you can catch all the scenarios and fulfill your needs. First of all tho, we will also learn how to create a custom colour.

### Custom Colours
One of the things we can customize in out new `LogType` are the Foreground (text) and Background colours. These colours are represented by the [AnsiColour class](https://github.com/dalibor-osu/PrettyLogSharp/blob/master/PrettyLogSharp/ANSI/AnsiColour.cs) that also allows us to create a custom colour using the `CreateCustom(int code)` method. All you need to do is pass the ANSI ID of the colour as a parameter to this method. You can find these in [this great gist post](https://gist.github.com/fnky/458719343aabd01cfb17a3a4f7296797) by [fnky](https://gist.github.com/fnky).

#### AnsiColourPair
As we will need 2 colours (Foreground and Background) to display our logs, there is a handy class [AnsiColourPair](https://github.com/dalibor-osu/PrettyLogSharp/blob/master/PrettyLogSharp/ANSI/AnsiColourPair.cs) that represents exactly this. All you need to do is create a new instance of it by calling its constructor `new AnsiColourPair(foreground, background)`.

### Creating a custom LogType
Now we know everything we need to be able to create our custom `LogType`. In the following example, we will create a custom `LogType` with custom background colour and set it as a default for Information logs.

```csharp
// First, we create our custom colour
var backgroundColour = AnsiColour.CreateCustom(112);

// Second, we need to create the colour pair.
var colourPair = new AnsiColourPair(Ansi.Colours.Black, backgroundColour);

// Now we can create our custom LogType...
var customLogType = LogType.CreateCustom("[CUSTOM]", colourPair, LogLevel.Information);

// .. and set it as a default for Information logs
var loggerDefaultLogTypes = new LoggerDefaultLogTypes
{
    Information = customLogType
};

// Now we have to assign it in the general settings class
var loggerSettings = new LoggerSettings { DefaultLogTypes = loggerDefaultLogTypes };

// Call the Initialize() method to properly load the settings
PrettyLogger.Initialize(loggerSettings);

// We can start logging!
PrettyLogger.Log("Our logs now have a custom look!");
PrettyLogger.Log("We can also explicitly use it in the Log() method.", customLogType);
PrettyLogger.Log("Previous pre-defined LogTypes are still available!", LogType.Information);
```

The output will look like this:

<img width="658" alt="image" src="https://github.com/dalibor-osu/PrettyLogSharp/assets/77931392/42160712-3987-4059-939c-17f7e74c013d">

As you may have noticed, we only created 1 custom colour. PrettyLog contains an [Ansi class](https://github.com/dalibor-osu/PrettyLogSharp/blob/master/PrettyLogSharp/ANSI/Ansi.cs) with some predefined values, including colours.

## Logger style
Last, but no least, visual thing we can customize is the logger style. There are currenly 4 different logger styles available, all in 2 different variants (with or without the timestamp). You can set the logger style in the general settings class as metioned above.

<img width="547" alt="image" src="https://github.com/dalibor-osu/PrettyLogSharp/assets/77931392/d73aa976-53c0-4a6f-8f64-d27cbed2b386">
