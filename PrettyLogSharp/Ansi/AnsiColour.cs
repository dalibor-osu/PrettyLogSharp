namespace PrettyLogSharp.Ansi;

public class AnsiColour
{
    public string Foreground { get; internal init; }
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

    public static AnsiColour CreateCustom(int code)
    {
        if (code is < 0 or > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(code), code, "ANSI code must be a value between 0 and 255.");
        }

        return new AnsiColour(code);
    }
}