using System.Text;
using Microsoft.Extensions.Logging;
using PrettyLogSharp.Ansi;
using PrettyLogSharp.Settings;

namespace PrettyLogSharp;

public sealed class PrettyLogger
{
    private static PrettyLogger? Instance { get; set; }

    private readonly LoggerSettings _settings;
    private readonly PrettyFileWriter? _fileWriter;
    private readonly Action<string> _logAction;

    private PrettyLogger(LoggerSettings settings)
    {
        _settings = settings;
        _logAction = settings.CustomLogAction ?? Console.WriteLine;
        
        if (_settings.FileWriterSettings.SaveToFile)
        {
            _fileWriter = new PrettyFileWriter(_settings.FileWriterSettings);
        }
    }
    
    private PrettyLogger() : this(new LoggerSettings())
    {
    }

    public static void Log(string message, LogType? logType = null)
    {
        if (Instance == null)
        {
            Initialize();
        }

        Instance!.LogInternal(message, logType);
    }

    public static void Log(string message, LogLevel logLevel)
    {
        if (Instance == null)
        {
            Initialize();
        }

        Instance!.LogInternal(message, logLevel);
    }

    public static void Log(Exception exception, LogType? logType = null)
    {
        if (Instance == null)
        {
            Initialize();
        }

        Instance!.LogInternal(exception, logType);
    }

    private void LogInternal(string message, LogType? logType = null)
    {
        logType ??= LogType.Information;

        if (logType.LogLevel < _settings.LogLevel)
        {
            return;
        }
        
        _logAction(GetFormattedMessage(message, logType));
        
        _fileWriter?.WriteLog(message, logType);
    }

    private void LogInternal(string message, LogLevel logLevel)
    {
        switch (logLevel)
        {
            case LogLevel.Trace:
                LogInternal(message, _settings.DefaultLogTypes.Trace);
                break;
            case LogLevel.Debug:
                LogInternal(message, _settings.DefaultLogTypes.Debug);
                break;
            case LogLevel.Information:
                LogInternal(message, _settings.DefaultLogTypes.Information);
                break;
            case LogLevel.Warning:
                LogInternal(message, _settings.DefaultLogTypes.Warning);
                break;
            case LogLevel.Error:
                LogInternal(message, _settings.DefaultLogTypes.Error);
                break;
            case LogLevel.Critical:
                LogInternal(message, _settings.DefaultLogTypes.Critical);
                break;
            case LogLevel.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
        }
    }

    private void LogInternal(Exception exception, LogType? logType = null)
    {
        logType ??= LogType.Exception;
        LogInternal(exception.Message, logType);

        if (exception.StackTrace == null)
        {
            return;
        }
        
        var lines = exception.StackTrace.Split('\n').Where(x => !string.IsNullOrEmpty(x));
        foreach (string line in lines)
        {
            LogInternal(line, logType);
        }
    }

    internal static void LogPrettyLog(string message)
    {
        if (Instance == null || Instance._settings.EnablePrettyLogLogs)
        {
            // We don't want to force instance creation for internal logs + internal logs are disabled by default
            return;
        }
        
        Console.WriteLine(Instance.GetFormattedMessage(message, LogType.Information));
    }

    public static void Initialize() => Instance = new PrettyLogger();
    public static void Initialize(LoggerSettings settings) => Instance = new PrettyLogger(settings);

    private string GetFormattedMessage(string message, LogType logType)
    {
        StringBuilder builder = new();
        switch (_settings.LoggerStyle)
        {
            case LoggerStyle.TextOnly:
                builder.Append(logType.Colour.Foreground);
                builder.Append(logType.Name);
                builder.Append(": ");
                break;

            case LoggerStyle.Prefix:
                builder.Append(logType.Colour.Background);
                builder.Append(AnsiCodes.Colours.Black.Foreground);
                builder.Append(logType.Name);
                builder.Append(':');
                builder.Append(AnsiCodes.Reset);
                builder.Append(' ');
                break;

            case LoggerStyle.Suffix:
                builder.Append(logType.Colour.Foreground);
                builder.Append(logType.Name);
                builder.Append(": ");
                builder.Append(logType.Colour.Background);
                builder.Append(AnsiCodes.Colours.Black.Foreground);
                break;

            case LoggerStyle.Full:
            default:
                builder.Append(logType.Colour.Background);
                builder.Append(AnsiCodes.Colours.Black.Foreground);
                builder.Append(logType.Name);
                builder.Append(": ");
                break;
        }

        builder.Append(message);
        builder.Append(AnsiCodes.Reset);
        return builder.ToString();
    }
}