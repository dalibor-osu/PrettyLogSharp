using Microsoft.Extensions.Logging;

namespace PrettyLogSharp.Settings;

/// <summary>
/// Class with various settings for <see cref="PrettyLogger"/>
/// </summary>
public sealed record LoggerSettings
{
    /// <summary>
    /// Minimal log level to log. Default value is "Debug".
    /// </summary>
    public LogLevel LogLevel { get; init; } = LogLevel.Debug;
    
    /// <summary>
    /// Style that will be used when displaying the log in console. Default value is FullWithTime.
    /// </summary>
    public LoggerStyle LoggerStyle { get; init; } = LoggerStyle.FullWithTime;
    
    /// <summary>
    /// Information whether the internal logs of PrettyLog should be logged as well. Default value is "false".
    /// </summary>
    public bool EnablePrettyLogLogs { get; init; } = false;
    
    /// <summary>
    /// Custom final log action. Standard console output is used when not set.
    /// </summary>
    public Action<string>? CustomLogAction { get; init; } = null;
    
    /// <summary>
    /// Information whether the logged timestamp should be in UTC or local time. This does not affect the
    /// timestamp that will be written in the log file. Default value is "false".
    /// </summary>
    public bool UseUtc { get; init; } = false;
    
    /// <summary>
    /// Format of a timestamp that will be logged. Timestamp is always prepended before the name of the <see cref="LogType"/>.
    /// Default value is "[HH:mm:ss:fff] ".
    /// </summary>
    public string TimeFormat { get; init; } = "[HH:mm:ss:fff] ";
    
    /// <summary>
    /// Information whether the global instance of <see cref="PrettyLogger"/> can be initialized again after it was
    /// already initialized one (to for example change the settings). It's highly recommended to leave this on "false".
    /// Changing the settings during app runtime can produce unexpected results. Default value is "false".
    /// </summary>
    public bool AllowInstanceReinitialization { get; init; } = false;
    
    /// <summary>
    /// Instance of <see cref="LoggerDefaultLogTypes"/> class that will be used for current <see cref="PrettyLogger"/>.
    /// <seealso cref="LoggerDefaultLogTypes"/>
    /// </summary>
    public LoggerDefaultLogTypes DefaultLogTypes { get; init; } = new();
    
    /// <summary>
    /// Instance of <see cref="FileWriterSettings"/> class that will be used for current <see cref="PrettyLogger"/> file writer.
    /// <seealso cref="FileWriterSettings"/>
    /// </summary>
    public FileWriterSettings FileWriterSettings { get; init; } = new();
}