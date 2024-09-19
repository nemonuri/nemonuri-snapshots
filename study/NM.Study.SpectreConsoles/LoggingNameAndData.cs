namespace NM.Study.SpectreConsoles;

public readonly struct LoggingNameAndData
{
    public LoggingNameAndData(string? name, string? dataAsString)
    {
        Name = name;
        this.dataAsString = dataAsString;
        dataAsNestedLogable = null;
    }

    public LoggingNameAndData(string? logName, INestedLogable? dataAsNestedLogable)
    {
        Name = logName;
        dataAsString = null;
        this.dataAsNestedLogable = dataAsNestedLogable;
    }

    public string? Name {get;}
    public string? dataAsString {get;}
    public INestedLogable? dataAsNestedLogable {get;}

}