namespace PrettyLogSharp.Settings;

/// <summary>
/// Class with various settings of PrettyLog's file writing.
/// </summary>
public sealed class FileWriterSettings
{
    /// <summary>
    /// Information whether logs should also be saved to file. Default value is "false".
    /// </summary>
    public bool SaveToFile { get; set; } = false;
    
    /// <summary>
    /// Path to a directory with log files. Default value is "./logs/".
    /// </summary>
    public string SaveDirectoryPath { get; init; } = "./logs/";
    
    /// <summary>
    /// Format which will be used to convert the current time to log file name. It can also be used to group logs by time.
    /// Default value is "yyyy-MM-dd".
    /// <example>When using the default value "yyyy-MM-dd", the smallest time part is a day, so
    /// logs will be grouped by day => new file is created every day.</example>
    /// </summary>
    public string LogFileNameFormat { get; init; } = "yyyy-MM-dd";
    
    /// <summary>
    /// Information whether the log file stream should stay open. Setting this to "true" might increase a write speed,
    /// but will block the file. Default value is "false".
    /// </summary>
    public bool KeepLogFileOpen { get; init; } = false;
    
    /// <summary>
    /// Format of a timestamp that will be written to the file. Timestamp is prepended before the log.
    /// Default value is "yyyy-MM-dd HH:mm:ss:fff"
    /// </summary>
    public string LogFileTimestampFormat { get; init; } = "yyyy-MM-dd HH:mm:ss:fff";
    
    /// <summary>
    /// Information whether timestamp in log file should be in UTC. Default value is "false".
    /// </summary>
    public bool UseUtc { get; init; } = false;
}