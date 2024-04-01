using Microsoft.Extensions.Logging;

namespace PrettyLogSharp.Settings;

/// <summary>
/// Class with default <see cref="LogType"/>s for certain <see cref="LogLevel"/>. Defaults must be set
/// so PrettyLog know which <see cref="LogType"/> to use when logging using <see cref="LogLevel"/>.
/// </summary>
public sealed record LoggerDefaultLogTypes
{
    /// <summary>
    /// Default <see cref="LogType"/> for <see cref="LogLevel"/>.Runtime
    /// </summary>
    public LogType Trace { get; init; } = LogType.Runtime;
    
    /// <summary>
    /// Default <see cref="LogType"/> for <see cref="LogLevel"/>.Debug
    /// </summary>
    public LogType Debug { get; init; } = LogType.Debug;
    
    /// <summary>
    /// Default <see cref="LogType"/> for <see cref="LogLevel"/>.Information
    /// </summary>
    public LogType Information { get; init; } = LogType.Information;
    
    /// <summary>
    /// Default <see cref="LogType"/> for <see cref="LogLevel"/>.Warning
    /// </summary>
    public LogType Warning { get; init; } = LogType.Warning;
    
    /// <summary>
    /// Default <see cref="LogType"/> for <see cref="LogLevel"/>.Error
    /// </summary>
    public LogType Error { get; init; } = LogType.Error;
    
    /// <summary>
    /// Default <see cref="LogType"/> for <see cref="LogLevel"/>.Critical
    /// </summary>
    public LogType Critical { get; init; } = LogType.Error;
}