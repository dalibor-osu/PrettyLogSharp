namespace PrettyLogSharp.ANSI;

/// <summary>
/// Static helper class for default ANSI terminal values which contains Other and Colours sub-classes.
/// </summary>
public static class Ansi
{
    /// <summary>
    /// Helper class for various ANSI terminal codes
    /// </summary>
    public static class Other
    {
        public const string Reset = "\u001B[0m";
    }
    
    /// <summary>
    /// Helper class for various ANSI terminal pre-defined colours
    /// </summary>
    public static class Colours
    {
        public static AnsiColour Black => new(232);
        public static AnsiColour Gray => new(244);
        public static AnsiColour Green => new(40);
        public static AnsiColour Red => new("\u001B[31m", "\u001B[41m");
        public static AnsiColour Yellow => new(220);
        public static AnsiColour Orange => new(202);
        public static AnsiColour Blue => new("\u001B[35m", "\u001B[44m");
        public static AnsiColour Purple => new("\u001B[35m", "\u001B[45m");
        public static AnsiColour CutePink => new(205);
        public static AnsiColour Pink => new(200);
        public static AnsiColour Cyan => new(43);
        public static AnsiColour Aqua => new(45);
        public static AnsiColour White => new(15);
    }
}