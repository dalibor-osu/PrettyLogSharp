namespace PrettyLogSharp.ANSI;

public class AnsiColourPair(AnsiColour foregroundColour, AnsiColour backgroundColour)
{
    public string Foreground { get; init; } = foregroundColour.Foreground;
    public string Background { get; init; } = backgroundColour.Background;
}