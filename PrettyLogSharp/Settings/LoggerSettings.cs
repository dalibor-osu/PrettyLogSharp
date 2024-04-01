using Microsoft.Extensions.Logging;

namespace PrettyLogSharp.Settings;

public sealed record LoggerSettings
{
    public LogLevel LogLevel { get; init; } = LogLevel.Debug;
    public LoggerStyle LoggerStyle { get; init; } = LoggerStyle.Full;
    public bool EnablePrettyLogLogs { get; init; } = false;
    public Action<string>? CustomLogAction { get; init; } = null;
    public bool UseUtc { get; init; } = false;
    public string TimeFormat { get; init; } = "[HH:mm:ss:fff] ";
    public bool AllowInstanceReinitialization { get; init; } = false;
    
    public LoggerDefaultLogTypes DefaultLogTypes { get; init; } = new();
    public FileWriterSettings FileWriterSettings { get; init; } = new();
}