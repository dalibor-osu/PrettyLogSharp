using System.Text;
using PrettyLogSharp.Settings;

namespace PrettyLogSharp;

internal sealed class PrettyFileWriter
{
    private readonly FileWriterSettings _settings;
    private FileStream? _fileStream = null;
    private string _currentFileName = string.Empty;
    private readonly Queue<Tuple<string, LogType, DateTimeOffset>> _writeQueue = new();

    internal PrettyFileWriter(FileWriterSettings settings)
    {
        _settings = settings;
    }

    internal void WriteLog(string message, LogType logType, DateTimeOffset dateTime)
    {
        var currentTime = _settings.UseUtc ? dateTime.ToUniversalTime() : dateTime.ToLocalTime();
        string fileName = GetFileNameForDateTime(currentTime);

        if (!fileName.Equals(_currentFileName))
        {
            CloseFile();
        }

        _fileStream ??= OpenFile(fileName);

        if (_fileStream is not { CanWrite: true })
        {
            _writeQueue.Enqueue(new Tuple<string, LogType, DateTimeOffset>(message, logType, currentTime));
            return;
        }

        while (_writeQueue.Count > 0)
        {
            var log = _writeQueue.Dequeue();
            WriteLogToFileStream(log.Item1, log.Item2, log.Item3);
        }

        WriteLogToFileStream(message, logType, currentTime);

        if (_settings.KeepLogFileOpen)
        {
            return;
        }

        CloseFile();
    }

    private void WriteLogToFileStream(string message, LogType logType, DateTimeOffset dateTime)
    {
        string timestamp = GetFormattedTimestampAsString(dateTime);
        using var streamWriter =
            new StreamWriter(_fileStream!, Encoding.UTF8, Encoding.UTF8.GetByteCount(message), false);
        streamWriter.WriteLine($"{timestamp} [{logType.Name}] {message}");
    }

    private FileStream? OpenFile(string fileName)
    {
        if (_fileStream != null)
        {
            PrettyLogger.LogPrettyLog("File stream is already open!");
        }

        string filePath = Path.Combine(_settings.SaveDirectoryPath, fileName);

        if (!Directory.Exists(_settings.SaveDirectoryPath))
        {
            Directory.CreateDirectory(_settings.SaveDirectoryPath);
        }

        FileStream fileStream;
        try
        {
            fileStream = !File.Exists(filePath) ? File.Create(filePath) : File.Open(filePath, FileMode.Append);
            _currentFileName = fileName;
        }
        catch
        {
            return null;
        }

        return fileStream;
    }

    private void CloseFile()
    {
        _fileStream?.Dispose();
        _fileStream = null;
        _currentFileName = string.Empty;
    }

    private string GetFileNameForDateTime(DateTimeOffset dateTime)
    {
        string fileName;
        try
        {
            fileName = dateTime.ToString(_settings.LogFileNameFormat);
        }
        catch
        {
            fileName = dateTime.ToString("yyyy-MM-dd");
        }

        return fileName;
    }

    private string GetFormattedTimestampAsString(DateTimeOffset dateTimeOffset)
    {
        string timestamp;
        try
        {
            timestamp = dateTimeOffset.ToString(_settings.LogFileTimestampFormat);
        }
        catch
        {
            timestamp = dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss:fff");
        }

        return timestamp;
    }

    ~PrettyFileWriter()
    {
        _fileStream?.Dispose();
    }
}