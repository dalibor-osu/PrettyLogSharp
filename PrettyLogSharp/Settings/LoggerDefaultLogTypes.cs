namespace PrettyLogSharp.Settings;

public sealed record LoggerDefaultLogTypes
{
    public LogType Trace { get; init; } = LogType.Runtime;
    public LogType Debug { get; init; } = LogType.Debug;
    public LogType Information { get; init; } = LogType.Information;
    public LogType Warning { get; init; } = LogType.Warning;
    public LogType Error { get; init; } = LogType.Error;
    public LogType Critical { get; init; } = LogType.Error;
}