namespace NM.Study.SpectreConsoles;

public readonly struct LoggingNameAndData
{
    public LoggingNameAndData(string? name, string? dataAsString)
    {
        Name = name;
        DataAsString = dataAsString;
        DataAsNestedLoggable = null;
    }

    public LoggingNameAndData(string? logName, INestedLoggable? dataAsNestedLoggable)
    {
        Name = logName;
        DataAsString = null;
        DataAsNestedLoggable = dataAsNestedLoggable;
    }

    public string? Name {get;}
    public string? DataAsString {get;}
    public INestedLoggable? DataAsNestedLoggable {get;}

}