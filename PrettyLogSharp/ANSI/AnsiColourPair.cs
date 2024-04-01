namespace PrettyLogSharp.ANSI;

/// <summary>
/// Class representing an ANSI terminal Foreground (text) and Background colour pair
/// </summary>
/// <param name="foregroundColour"><see cref="AnsiColour"/> that will be used as a foreground colour.</param>
/// <param name="backgroundColour"><see cref="AnsiColour"/> that will be used as a background colour.</param>
public sealed class AnsiColourPair(AnsiColour foregroundColour, AnsiColour backgroundColour)
{
    /// <summary>
    /// Gets a Foreground (text) colour of a current pair
    /// </summary>
    public string Foreground { get; init; } = foregroundColour.Foreground;
    
    /// <summary>
    /// Gets a Background colour of a current pair
    /// </summary>
    public string Background { get; init; } = backgroundColour.Background;
}