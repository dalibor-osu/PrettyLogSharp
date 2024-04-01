using System.Text;

namespace PrettyLogSharp.Extensions;

internal static class StringBuilderExtensions
{
    internal static StringBuilder AppendDateTime(this StringBuilder builder, DateTimeOffset dateTime, string dateTimeFormat)
    {
        return builder.Append(dateTime.ToString(dateTimeFormat));
    }
}