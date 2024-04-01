namespace PrettyLogSharp.Extensions;

internal static class LoggerStyleExtensions
{
    internal static bool IsWithTime(this LoggerStyle loggerStyle)
    {
        // For now, every odd item in LoggerStyle enum is a value with time
        return (int)loggerStyle % 2 == 1;
    }
}