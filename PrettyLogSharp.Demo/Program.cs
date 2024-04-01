using Microsoft.Extensions.Logging;
using PrettyLogSharp;
using PrettyLogSharp.Ansi;
using PrettyLogSharp.Settings;

// We can create a custom colour which can be used for out custom LogType
var customColour = AnsiColour.CreateCustom(171);
var customColourPair = new AnsiColourPair(customColour, AnsiCodes.Colours.Black);

// As mentioned above, we can create a custom LogType which can later be used for log formatting
var customLogType = LogType.CreateCustom("[Custom]", customColourPair, LogLevel.Debug);

// We can also set a custom default LogType for certain LogLevel
var defaultLogTypes = new LoggerDefaultLogTypes { Debug = customLogType };

var fileWriterSettings = new FileWriterSettings { UseUtc = true };

// This, as well as other options, can then be used when initializing the PrettyLogger
// Note that without calling the Initialize() method default settings will be used!
PrettyLogger.Initialize(new LoggerSettings
{
    DefaultLogTypes = defaultLogTypes,
    FileWriterSettings = fileWriterSettings,
    LogLevel = LogLevel.Trace,
    LoggerStyle = LoggerStyle.FullWithTime
});

// Now, we can start logging!
PrettyLogger.Log("Running demonstration!", LogType.Debug);
PrettyLogger.Log("This is an information log!", LogType.Information);
PrettyLogger.Log("This is a runtime log!", LogType.Runtime);
PrettyLogger.Log("This is a network log!", LogType.Network);
PrettyLogger.Log("This is a success log!", LogType.Success);
PrettyLogger.Log("This is a warning log!", LogType.Warning);
PrettyLogger.Log("This is an error log!", LogType.Error);

PrettyLogger.Log("You can also use a LogLevel!", LogLevel.Information);
PrettyLogger.Log("Using LogLevel will automatically use the default LogType which can be customized!", LogLevel.Debug);

try
{
    int.Parse("Definitely not... a number");
}
catch (Exception exception)
{
    PrettyLogger.Log(exception);
}