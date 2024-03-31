using Microsoft.Extensions.Logging;
using PrettyLogSharp.Ansi;

namespace PrettyLogSharp;

public sealed class LogType
{
    public string Name { get; private set; }
    public AnsiColour Colour { get; private set; }
    public LogLevel LogLevel { get; private set; }

    private LogType(string name, AnsiColour colour, LogLevel logLevel)
    {
        Name = name;
        Colour = colour;
        LogLevel = logLevel;
    }
    
    public static LogType Information =>
        new("ℹ\uFE0F Information", AnsiCodes.Colours.Cyan, LogLevel.Information);
    
    public static LogType Runtime =>
        new("✨ Runtime", AnsiCodes.Colours.Pink, LogLevel.Trace);
    
    public static LogType Debug =>
        new("\uD83D\uDD27 Debug", AnsiCodes.Colours.Gray, LogLevel.Information);
    
    public static LogType Network =>
        new("\uD83D\uDD0C Network", AnsiCodes.Colours.Blue, LogLevel.Information);
    
    public static LogType Success =>
        new("✔\uFE0F Success", AnsiCodes.Colours.Green, LogLevel.Information);
    
    public static LogType Warning =>
        new("⚠\uFE0F Warning", AnsiCodes.Colours.Yellow, LogLevel.Warning);
    
    public static LogType Error =>
        new("⛔ Error", AnsiCodes.Colours.Red, LogLevel.Error);
    
    public static LogType Exception =>
        new("\uD83D\uDCA3 Exception", AnsiCodes.Colours.Red, LogLevel.Critical);
    
    internal static LogType Log =>
        new("[PrettyLog]", AnsiCodes.Colours.CutePink, LogLevel.Debug);

    public static LogType CreateCustom(string name, AnsiColour colour, LogLevel logLevel = LogLevel.Information) =>
        new(name, colour, logLevel);
}