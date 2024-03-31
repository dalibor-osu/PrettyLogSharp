using Microsoft.Extensions.Logging;

namespace PrettyLogSharp.Settings;

public sealed record LoggerSettings
{
    public LogLevel LogLevel { get; init; } = LogLevel.Information;
    public LoggerStyle LoggerStyle { get; init; } = LoggerStyle.Full;
    public bool EnablePrettyLogLogs { get; init; } = false;
    public Action<string>? CustomLogAction { get; set; } = null;
    
    public LoggerDefaultLogTypes DefaultLogTypes { get; init; } = new();
    public FileWriterSettings FileWriterSettings { get; init; } = new();
}