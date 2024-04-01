using Microsoft.Extensions.Logging;
using PrettyLogSharp.ANSI;
using static PrettyLogSharp.ANSI.Ansi.Colours;

namespace PrettyLogSharp;

/// <summary>
/// Class representing a PrettyLog's type of the log. It's used in a similar way as <see cref="LogLevel"/>, but it also
/// contains formatting information and colours.
/// </summary>
public sealed class LogType
{
    /// <summary>
    /// Name of the <see cref="LogType"/>. This will be prepended before the actual message.
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// ANSI terminal colours that will be used when logging with this type
    /// </summary>
    public AnsiColourPair Colours { get; private set; }
    
    /// <summary>
    /// Log level of this type which is checked and if the minimal log level is higher, log with this log type is ignored.
    /// </summary>
    public LogLevel LogLevel { get; private set; }

    private LogType(string name, AnsiColourPair colours, LogLevel logLevel)
    {
        Name = name;
        Colours = colours;
        LogLevel = logLevel;
    }
    
    /// <summary>
    /// Predefined type for basic Information log.
    /// </summary>
    public static LogType Information =>
        new("ℹ\uFE0F Information", new AnsiColourPair(Black, Cyan), LogLevel.Information);
    
    /// <summary>
    /// Predefined type for basic Runtime log.
    /// </summary>
    public static LogType Runtime =>
        new("✨ Runtime", new AnsiColourPair(Black, Pink), LogLevel.Trace);
    
    /// <summary>
    /// Predefined type for basic Debug log.
    /// </summary>
    public static LogType Debug =>
        new("\uD83D\uDD27 Debug", new AnsiColourPair(Black, Gray), LogLevel.Debug);
    
    /// <summary>
    /// Predefined type for basic Network log.
    /// </summary>
    public static LogType Network =>
        new("\uD83D\uDD0C Network", new AnsiColourPair(Black, Blue), LogLevel.Information);
    
    /// <summary>
    /// Predefined type for basic Success log.
    /// </summary>
    public static LogType Success =>
        new("✔\uFE0F Success", new AnsiColourPair(Black, Green), LogLevel.Information);
    
    /// <summary>
    /// Predefined type for basic Warning log.
    /// </summary>
    public static LogType Warning =>
        new("⚠\uFE0F Warning", new AnsiColourPair(Black, Yellow), LogLevel.Warning);
    
    /// <summary>
    /// Predefined type for basic Error log.
    /// </summary>
    public static LogType Error =>
        new("⛔ Error", new AnsiColourPair(Black, Red), LogLevel.Error);
    
    /// <summary>
    /// Predefined type for basic Exception log.
    /// </summary>
    public static LogType Exception =>
        new("\uD83D\uDCA3 Exception", new AnsiColourPair(Black, Red), LogLevel.Critical);
    
    /// <summary>
    /// Predefined type used for all PrettyLog's logs.
    /// </summary>
    internal static LogType PrettyLog => 
        new("[PrettyLog]", new AnsiColourPair(Black, CutePink), LogLevel.Debug);

    /// <summary>
    /// Explicitly creates a new custom instance of <see cref="LogType"/> and returns it.
    /// </summary>
    /// <param name="name">Name of the custom type</param>
    /// <param name="colours">Colours that will be used when logging with this custom log type</param>
    /// <param name="logLevel">Log level of the custom log type</param>
    /// <returns>A new instance of <see cref="LogType"/></returns>
    public static LogType CreateCustom(string name, AnsiColourPair colours, LogLevel logLevel = LogLevel.Debug) =>
        new(name, colours, logLevel);
}