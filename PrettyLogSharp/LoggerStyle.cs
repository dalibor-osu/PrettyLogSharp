namespace PrettyLogSharp;

/// <summary>
/// Available visual styles of the <see cref="PrettyLogger"/>.
/// </summary>
public enum LoggerStyle
{
    /// <summary>
    /// The whole log message has a background.
    /// </summary>
    Full,
    
    /// <summary>
    /// The whole log message has a background and is prepended with timestamp
    /// </summary>
    FullWithTime,
    
    /// <summary>
    /// Only the prefix (name) has background and different text colour.
    /// </summary>
    Prefix,
    
    /// <summary>
    /// Only the prefix (name) and timestamp has background and different text colour.
    /// </summary>
    PrefixWithTime,
    
    /// <summary>
    /// Only the message has background and different text colour.
    /// </summary>
    Suffix,
    
    /// <summary>
    /// Only the message has background and different text colour. The whole log is also prepended with timestamp.
    /// </summary>
    SuffixWithTime,
    
    /// <summary>
    /// Only text colour is changed.
    /// </summary>
    TextOnly,
    
    /// <summary>
    /// Only text colour is changed and the whole log is prepended with timestamp.
    /// </summary>
    TextOnlyWithTime
}