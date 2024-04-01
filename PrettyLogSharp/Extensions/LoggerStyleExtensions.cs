namespace PrettyLogSharp.Extensions;

internal static class LoggerStyleExtensions
{
    internal static bool IsWithTime(this LoggerStyle loggerStyle)
    {
        return (int)loggerStyle % 2 == 1;
    }
}