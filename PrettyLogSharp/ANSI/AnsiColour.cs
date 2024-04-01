namespace PrettyLogSharp.ANSI;

/// <summary>
/// Class representing an ANSI terminal colour. It contains properties for Foreground (text) and Background colours
/// </summary>
public sealed class AnsiColour
{
    /// <summary>
    /// Gets an foreground ANSI terminal code for current colour
    /// </summary>
    public string Foreground { get; internal init; }

    /// <summary>
    /// Gets an background ANSI terminal code for current colour
    /// </summary>
    public string Background { get; internal init; }

    internal AnsiColour(int code)
    {
        Foreground = $"\u001B[38;5;{code}m";
        Background = $"\u001B[48;5;{code}m";
    }

    internal AnsiColour(string foreground, string background)
    {
        Foreground = foreground;
        Background = background;
    }

    /// <summary>
    /// Creates a new instance of ANSI colour and returns it.
    /// </summary>
    /// <param name="code">ANSI ID of the desired terminal colour. This value must be between 0 and 255.</param>
    /// <returns>A new instance of <see cref="AnsiColour"/> specified by <paramref name="code"/> parameter.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="code"/> parameter is not a value between 0 and 255.</exception>
    public static AnsiColour CreateCustom(int code)
    {
        if (code is < 0 or > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(code), code, "ANSI code must be a value between 0 and 255.");
        }

        return new AnsiColour(code);
    }
}