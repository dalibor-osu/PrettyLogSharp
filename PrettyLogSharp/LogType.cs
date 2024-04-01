using Microsoft.Extensions.Logging;
using PrettyLogSharp.ANSI;
using static PrettyLogSharp.ANSI.Ansi.Colours;

namespace PrettyLogSharp;

public sealed class LogType
{
    public string Name { get; private set; }
    public AnsiColourPair Colours { get; private set; }
    public LogLevel LogLevel { get; private set; }

    private LogType(string name, AnsiColourPair colours, LogLevel logLevel)
    {
        Name = name;
        Colours = colours;
        LogLevel = logLevel;
    }
    
    public static LogType Information =>
        new("ℹ\uFE0F Information", new AnsiColourPair(Black, Cyan), LogLevel.Information);
    
    public static LogType Runtime =>
        new("✨ Runtime", new AnsiColourPair(Black, Pink), LogLevel.Trace);
    
    public static LogType Debug =>
        new("\uD83D\uDD27 Debug", new AnsiColourPair(Black, Gray), LogLevel.Debug);
    
    public static LogType Network =>
        new("\uD83D\uDD0C Network", new AnsiColourPair(Black, Blue), LogLevel.Information);
    
    public static LogType Success =>
        new("✔\uFE0F Success", new AnsiColourPair(Black, Green), LogLevel.Information);
    
    public static LogType Warning =>
        new("⚠\uFE0F Warning", new AnsiColourPair(Black, Yellow), LogLevel.Warning);
    
    public static LogType Error =>
        new("⛔ Error", new AnsiColourPair(Black, Red), LogLevel.Error);
    
    public static LogType Exception =>
        new("\uD83D\uDCA3 Exception", new AnsiColourPair(Black, Red), LogLevel.Critical);
    
    internal static LogType PrettyLog => 
        new("[PrettyLog]", new AnsiColourPair(Black, CutePink), LogLevel.Debug);

    public static LogType CreateCustom(string name, AnsiColourPair colours, LogLevel logLevel = LogLevel.Debug) =>
        new(name, colours, logLevel);
}